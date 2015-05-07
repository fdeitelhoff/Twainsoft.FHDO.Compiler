using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Resources;

namespace Twainsoft.FHDO.Compiler.Scanner
{
    public class TestScanner
    {
        // Definition der Token
        public const int OPEN = 1000;
        public const int CLOSE = 1001;
        public const int INTEGER = 1002;
        public const int REAL = 1003;

        // weitere Token ...

        // Fehler beim Scannen
        public const int ERROR = 2000;

        // Kein Zustandsdiagramm passend
        // Folgezustand dann ERROR_STATE
        public const int ERROR_STATE = -1;

        // Puffer fuer Eingabezeichenfolge
        private char[] buffer;

        // Positionen in Puffer
        private int pos = 0;            // Das nächste zu lesende Zeichen
        private int start_pos = 0;      // Einstieg für das Zustandsdiagramm.

        // Zustaende
        private int state;
        private int start_state;
        

        public TestScanner(string input)
        {
            input = input + "*";
            buffer = input.ToCharArray();
        }

        /// <summary>
        /// IndexOutOfBoundsException
        /// </summary>
        /// <returns></returns>
        private char NextChar()
        {
            return buffer[pos++];
        }

        private void StepBack()
        {
            pos--;
        }

        private bool IsDigit(char c)
        {
            return Char.IsDigit(c);
        }

        private bool IsDelim(char c)
        {
            return c == '\t' || c == '\n' || c == ' ';
        }

        private bool IsSign(char c)
        {
            return c == '+' || c == '-';
        }

        private int NextDiagram()
        {
            pos = start_pos; // Deswegen merken wir uns die Start-Post, um im Fehlerfall daraufhin als Start zurückspringen zu können!

            switch (start_state)
            {
                case 0: start_state = 2;
                    break;
                case 2: start_state = 4;
                    break;
                //case 6: start_state = 7;
                //    break;
                case 4: start_state = 7;
                    break;
            }

            return start_state;
        }

        // Gibt die Position des als nächstes zu lesenden Zeichens zurück
        public int GetPos()
        {
            return pos;
        }

        private int GetToken()
        {
            char c;
            state = 0;
            start_state = 0;
            while (true)
            {
                switch (state)
                {
                    // Token OPEN
                    case 0:
                        c = NextChar();
                        if (c == '(')
                        {
                            state = 1;
                        }
                        else
                        {
                            state = NextDiagram();
                        }
                        break;
                    case 1:
                        start_pos = pos;
                        return OPEN;
                    // Token CLOSE
                    case 2:
                        c = NextChar();
                        if (c == ')')
                        {
                            state = 3;
                        }
                        else
                        {
                            state = NextDiagram();
                        }
                        break;
                    case 3:
                        start_pos = pos;
                        return (CLOSE);
                    case 4:
                        c = NextChar();
                        if (IsDelim(c))
                        {
                            state = 5;
                        }
                        else
                        {
                            state = NextDiagram();
                        }
                        break;
                    case 5:
                        c = NextChar();

                        if (!IsDelim(c))
                        {
                            state = 6;
                        }
                        break;
                    case 6:
                        StepBack();
                        state = 0;
                        start_state = 0;
                        start_pos = pos;
                        break;
                    default:
                        return ERROR;
                }
            }
        }

        public List<int> GetTokenList()
        {
            var tokenList = new List<int>();
            var token = 0;

            while (pos < buffer.Length)
            {
                token = GetToken();

                if (token == ERROR_STATE)
                {
                    return new List<int>();
                }

                tokenList.Add(token);
            }

            return tokenList;
        }
    }
}
