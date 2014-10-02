using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace LumenCompiler
{
    
    /*
    * instruction: byte1 & 0b11111000
    * register: byte1 & 0b00000111
    */

    public partial class Form1 : Form
    {
        //enum of instructions to keep source code clean
        public enum Instructions { Init, Assign, Increment, Decrement, Add, Substract, Multiply, Divide, Equal, While, For, If, End, Comment };

        Dictionary<string, int> instructionSet = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();

            //Mathematical
            instructionSet.Add("ADD", 0x08);
            instructionSet.Add("SUB", 0x09);
            instructionSet.Add("MUL", 0x0A);
            instructionSet.Add("DIV", 0x0B);
            instructionSet.Add("INC", 0x0C);
            instructionSet.Add("DEC", 0x0D);
            instructionSet.Add("PWR", 0x0E);
            instructionSet.Add("SQRT", 0x0F);
            //Logic
            instructionSet.Add("AND", 0x10);
            instructionSet.Add("OR", 0x11);
            instructionSet.Add("NOT", 0x12);
            instructionSet.Add("XOR", 0x13);
            //Variables
            instructionSet.Add("LD", 0x14);
            instructionSet.Add("LDR", 0x15);
            instructionSet.Add("ST", 0x16);
            instructionSet.Add("LR", 0x17);
            instructionSet.Add("EQU", 0x18);
            //Calls
            instructionSet.Add("JMP", 0x19);
            instructionSet.Add("JMPZ", 0x1A);
            instructionSet.Add("CALL", 0x1B);
            instructionSet.Add("RET", 0x1C);
            instructionSet.Add("DLY", 0x1D);
            //Stack
            instructionSet.Add("PUSH", 0x1E);
            instructionSet.Add("POP", 0x1F);
            //Graphics
            instructionSet.Add("GS", 0x20);
            instructionSet.Add("GM", 0x21);
            //Sound
            instructionSet.Add("PLN", 0x22);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stack nestingStack = new Stack();       //stacks the PC of instructions for e.g. while to jump back to
            StringBuilder builder = new StringBuilder();

            compileProgress.Value = 0;
            
            string inputStr = inputTxt.Text;
            string[] inputLines = inputStr.Split('\n');
            int pc = 0;

            Console.WriteLine("Inputlines: " + inputLines.Count());

            List<Regex> instr = new List<Regex>();
            // var i = 5
            instr.Add(new Regex(@"^\s*var\s[a-z]\s*=\s*[a-z0-9]"));
            // i = 5
            instr.Add(new Regex(@"^\s*[a-z]\s*=\s*[a-z0-9]"));
            // i++
            instr.Add(new Regex(@"^\s*[a-z]\+\+"));
            // i--
            instr.Add(new Regex(@"^\s*[a-z]\-\-"));
            // i+=5
            instr.Add(new Regex(@"^\s*[a-z]\s*\+=\s*[a-z0-9]"));
            // i-=5
            instr.Add(new Regex(@"^\s*[a-z]\s*\-=\s*[a-z0-9]"));
            // i*=5
            instr.Add(new Regex(@"^\s*[a-z]\s*\*=\s*[a-z0-9]"));
            // i/=5
            instr.Add(new Regex(@"^\s*[a-z]\s*/=\s*[a-z0-9]"));
            // i?j
            instr.Add(new Regex(@"^\s*[a-z]\s*\?\s*[a-z0-9]"));
            // while(i)
            instr.Add(new Regex(@"^\s*while\(\s*[a-z]+\s*\)"));
            // for(i=0,5,i++)
            instr.Add(new Regex(@"^\s*for\(\s*[a-z]+\s*=\s*\d*\s*,\s*[a-z0-9]\s*,\s*[a-z](\+\+|\-\-)\s*\)"));
            // if
            instr.Add(new Regex(@"^\s*if\s*\(\s*[a-z]+\s*==\s*[a-z0-9]\s*\)"));
            // end
            instr.Add(new Regex(@"^\s*end"));
            // Comments
            instr.Add(new Regex(@"//.*"));
            // function call
            instr.Add(new Regex(@""));

            for (int i = 0; i<inputLines.Count(); i++)
            {
                Console.WriteLine("");
                Console.WriteLine("New Line (" + i + ")");
                compileProgress.Value = (int)100*(i+1)/inputLines.Count();
                string cIn = inputLines[i];

                for(int j = 0; j<instr.Count(); j++)
                {
                    Regex reg = instr[j];

                    if(reg.IsMatch(cIn))
                    {
                        Console.WriteLine("reg.IsMatch(cIn): " + cIn.Remove(cIn.Length - 1) + " with regex " + reg.ToString());
                        Console.WriteLine("Nesting depth: " + nestingStack.Count);
                        List<string> instrToAdd = new List<string>();

                        switch(j)
                        {
                            case (int)Instructions.Init:
                                string input = Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[a-z0-9]+").ToString().Trim();
                                try
                                {
                                    int k = Convert.ToInt16(input);
                                    instrToAdd.Add("LD " + Regex.Match(cIn, @"\s.\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[0-9]+").ToString().Trim());
                                }
                                catch
                                {
                                    instrToAdd.Add("LDR " + Regex.Match(cIn, @"\s.\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[a-z]+").ToString().Trim());
                                }
                                break;
                            case (int)Instructions.Assign:
                                string input2 = Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[a-z0-9]+").ToString().Trim();
                                try
                                {
                                    int k = Convert.ToInt16(input2);
                                    instrToAdd.Add("LD " + Regex.Match(cIn, @"[a-z]+\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[0-9]+").ToString().Trim());
                                }
                                catch
                                {
                                    instrToAdd.Add("LDR " + Regex.Match(cIn, @"[a-z]+\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[a-z]+").ToString().Trim());
                                }
                                break;
                            case (int)Instructions.Increment:
                                instrToAdd.Add("INC " + Regex.Match(cIn, @"[a-z]+").ToString().Trim());
                                break;
                            case (int)Instructions.Decrement:
                                instrToAdd.Add("DEC " + Regex.Match(cIn, @"[a-z]+").ToString().Trim());
                                break;
                            case (int)Instructions.Add:
                                instrToAdd.Add("ADD " + Regex.Match(cIn, @".\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[a-z]+").ToString().Trim());
                                break;
                            case (int)Instructions.Substract:
                                instrToAdd.Add("SUB " + Regex.Match(cIn, @".\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[a-z]+").ToString().Trim());
                                break;
                            case (int)Instructions.Multiply:
                                instrToAdd.Add("MUL " + Regex.Match(cIn, @".\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[a-z]+").ToString().Trim());
                                break;
                            case (int)Instructions.Divide:
                                instrToAdd.Add("DIV " + Regex.Match(cIn, @".\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("=")), @"\s*[a-z]+").ToString().Trim());
                                break;
                            case (int)Instructions.Equal:
                                instrToAdd.Add("EQU " + Regex.Match(cIn, @".\s*").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("?")), @"\s*[a-z]+").ToString().Trim());
                                break;
                            case (int)Instructions.While:
                                nestingStack.Push(new NestingType(pc+1, true));
                                Console.WriteLine("Pushed to stack!");
                                instrToAdd.Add("EQU " + Regex.Match(cIn.Substring(cIn.IndexOf("(")), @"\s*[a-z]+\s*").ToString().Trim() + ",0");
                                instrToAdd.Add("JMPZ ");
                                break;
                            case (int)Instructions.For:
                                nestingStack.Push(new NestingType(pc + 2, true));
                                Console.WriteLine("Pushed to stack!");

                                string forVar = Regex.Match(cIn.Substring(cIn.IndexOf("(")), @"\s*[a-z]+\s*").ToString().Trim();
                                string forStartVal = Regex.Match(cIn.Substring(cIn.IndexOf("(")), @"\s*[0-9]+\s*").ToString().Trim();
                                string forEndVal = Regex.Match(cIn.Substring(cIn.IndexOf(",")), @"\s*[a-z0-9]+\s*,").ToString().Trim();
                                forEndVal = forEndVal.Remove(forEndVal.Length - 1);
                                string incrementer = Regex.Match(cIn.Substring(cIn.LastIndexOf(",")), @"(\+\+|\-\-)").ToString().Trim();
                                
                                instrToAdd.Add("LD " + forVar + "," + forStartVal);
                                instrToAdd.Add("EQU " + forVar + "," + forEndVal);
                                instrToAdd.Add("JMPZ ");
                                instrToAdd.Add(((incrementer=="++")?"INC ":"DEC ") + forVar);
                                break;
                            case (int)Instructions.If:
                                nestingStack.Push(new NestingType(pc+1, false));
                                Console.WriteLine("Pushed to stack!");
                                instrToAdd.Add("EQU " + Regex.Match(cIn.Substring(cIn.IndexOf("(")), @"\s*[a-z]+").ToString().Trim() + "," + Regex.Match(cIn.Substring(cIn.IndexOf("==")+2), @"\s*[a-z0-9]+").ToString().Trim());
                                instrToAdd.Add("JMPZ ");
                                break;
                            case (int)Instructions.End:
                                NestingType nest = (NestingType)nestingStack.Pop();
                                if (nest.JMP)
                                    instrToAdd.Add("JMP " + nest.PC);
                                string[] array = builder.ToString().Split('\n');
                                array[nest.PC] = array[nest.PC] + (pc+(nest.JMP?2:1));
                                builder.Clear();
                                builder.Append(String.Join("\r\n", array));
                                break;
                            case (int)Instructions.Comment:
                                break;
                            default:
                                break;
                        }

                        int m = instrToAdd.Count();
                        pc += m;

                        foreach (string str in instrToAdd)
                        {
                            builder.Append(/*"" + (pc-m+1) + ((pc > 9) ? "" : " ") + " | " + */str + "\r\n");
                            Console.WriteLine("Added intstruction: " + str);
                            m--;
                        }
                    }
                }
            }

            pseudoTxt.Text = builder.ToString().Trim();

            addCodeToGridView();
            addBytecodeToGridView();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            int[] ram = new int[27];
            int[] stack = new int[16];

            for(int i = 0; i<pseudoTxt.Text.Split('\n').Count(); i++)
            {
                string str = pseudoTxt.Text.Split('\n')[i];

                if(str.StartsWith("LD"))
                {
                    int k = stringToAlfabet(str.Substring(str.IndexOf(" ") + 1, 1));
                    string op2 = str.Substring(str.IndexOf(",") + 1);

                    try
                    {
                        int m = Convert.ToInt16(op2);
                        ram[k] = m;
                    }
                    catch
                    {
                        ram[k] = ram[stringToAlfabet(op2)];
                    }
                }
                else if(str.StartsWith("ADD"))
                {
                    int k = stringToAlfabet(str.Substring(str.IndexOf(" ") + 1, 1));
                    string op2 = str.Substring(str.IndexOf(",")+1);
                    try
                    {
                        int m = Convert.ToInt16(op2);
                        ram[k] = ram[k] + m;
                    }
                    catch
                    {
                        ram[k] = ram[k] + ram[stringToAlfabet(op2)];
                    }
                }
                else if (str.StartsWith("SUB"))
                {
                    int k = stringToAlfabet(str.Substring(str.IndexOf(" ") + 1, 1));
                    string op2 = str.Substring(str.IndexOf(",") + 1);
                    try
                    {
                        int m = Convert.ToInt16(op2);
                        ram[k] = ram[k] - m;
                    }
                    catch
                    {
                        ram[k] = ram[k] - ram[stringToAlfabet(op2)];
                    }
                }
                else if (str.StartsWith("MUL"))
                {
                    int k = stringToAlfabet(str.Substring(str.IndexOf(" ") + 1, 1));
                    string op2 = str.Substring(str.IndexOf(",") + 1);
                    try
                    {
                        int m = Convert.ToInt16(op2);
                        ram[k] = ram[k] * m;
                    }
                    catch
                    {
                        ram[k] = ram[k] * ram[stringToAlfabet(op2)];
                    }
                }
                else if (str.StartsWith("DIV"))
                {
                    int k = stringToAlfabet(str.Substring(str.IndexOf(" ") + 1, 1));
                    string op2 = str.Substring(str.IndexOf(",") + 1);
                    try
                    {
                        int m = Convert.ToInt16(op2);
                        ram[k] = ram[k] / m;
                    }
                    catch
                    {
                        ram[k] = ram[k] / ram[stringToAlfabet(op2)];
                    }
                }
            }

            for(int i = 1; i<27; i++)
            {
                ramLst.Items[i] = ram[i];
            }
        }

        private int stringToAlfabet(string s)
        {
            if (!String.IsNullOrEmpty(s.Trim()))
            {
                try
                {
                    int i = Convert.ToInt16(s);
                    return i>255?255:i;
                }
                catch
                {
                    return s.ToLower().ToCharArray()[0] - 96;
                }
            }
            
            return 0;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<ramLst.Items.Count; i++)
            {
                ramLst.Items[i] = 0;
            }
        }

        private void addCodeToGridView()
        {
            // 5 bit instruction
            // 3 bit register address
            // optionally 1 or 2 extra data bytes
            string[] code = pseudoTxt.Text.Split('\n');
            string[,] instr = new string[code.Count(), 4];

            for (int i = 0; i < code.Count(); i++)
            {
                string[] tmpStr = code[i].Split(new char[] { ' ', ',' });
                instr[i, 0] = tmpStr.Count() > 0 ? tmpStr[0] : "";
                instr[i, 1] = tmpStr.Count() > 1 ? tmpStr[1] : "";
                instr[i, 2] = tmpStr.Count() > 2 ? tmpStr[2] : "";
                instr[i, 3] = tmpStr.Count() > 3 ? tmpStr[3] : "";
            }

            var rowCount = instr.GetLength(0);
            var rowLength = instr.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                var row = new DataGridViewRow();

                for (int columnIndex = 0; columnIndex < rowLength; ++columnIndex)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = instr[rowIndex, columnIndex]
                    });
                }

                bytecodeView.Rows.Add(row);
            }
        }

        private void addBytecodeToGridView()
        {
            // 5 bit instruction
            // 3 bit register address
            // optionally 1 or 2 extra data bytes
            string[] code = pseudoTxt.Text.Split('\n');
            string[,] instr = new string[code.Count(), 4];

            List<Byte> resultLst = new List<byte>();

            resultTxt.Text = "";

            for (int i = 0; i < code.Count(); i++)
            {
                string[] tmpStr = code[i].Split(new char[] { ' ', ',' });
                instr[i, 0] = tmpStr.Count() > 0 ? tmpStr[0] : "";
                instr[i, 1] = tmpStr.Count() > 1 ? tmpStr[1] : "";
                instr[i, 2] = tmpStr.Count() > 2 ? tmpStr[2] : "";
                instr[i, 3] = tmpStr.Count() > 3 ? tmpStr[3] : "";
            }

            var rowCount = instr.GetLength(0);
            var rowLength = instr.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                var row = new DataGridViewRow();

                Console.WriteLine(instr[rowIndex, 0].Trim());

                row.Cells.Add(new DataGridViewTextBoxCell() { Value = String.Format("{0:X}", instructionSet[instr[rowIndex, 0].Trim()]) });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = stringToAlfabet(instr[rowIndex, 1]) });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = stringToAlfabet(instr[rowIndex, 2]) });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = stringToAlfabet(instr[rowIndex, 3]) });

                resultTxt.AppendText(String.Format("{0:x} ", instructionSet[instr[rowIndex, 0].Trim()] + stringToAlfabet(instr[rowIndex, 1]) ));
                resultLst.Add((byte)(instructionSet[instr[rowIndex, 0].Trim()] + stringToAlfabet(instr[rowIndex, 1])));
                if (!String.IsNullOrEmpty(instr[rowIndex, 2]))
                {
                    resultTxt.AppendText(String.Format("{0:x} ", stringToAlfabet(instr[rowIndex, 2])));
                    resultLst.Add((byte)(stringToAlfabet(instr[rowIndex, 2])));
                }
                if (!String.IsNullOrEmpty(instr[rowIndex, 3]))
                {
                    resultTxt.AppendText(String.Format("{0:x} ", stringToAlfabet(instr[rowIndex, 3])));
                    resultLst.Add((byte)(stringToAlfabet(instr[rowIndex, 3])));
                }

                byteView.Rows.Add(row);
            }

            byte[] resultArray = resultLst.ToArray();
            File.WriteAllBytes(@"C:\Users\Nick\Desktop\file.hex", resultArray);
        }
    }
}
