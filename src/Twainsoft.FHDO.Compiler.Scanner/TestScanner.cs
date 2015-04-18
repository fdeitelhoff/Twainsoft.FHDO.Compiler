using System.Collections.Generic;

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
        private int pos = 0;
        private int start_pos = 0;

        // Zustaende
        private int state;
        private int start_state;
        

        public TestScanner(string strBuffer)
        {
            // ...
        }

        /// <summary>
        /// IndexOutOfBoundsException
        /// </summary>
        /// <returns></returns>
        private char NextChar()
        {
            // ...
            return ' ';
        }

        private void StepBack()
        {
            // ...
        }

        private bool IsDigit(char c)
        {
            // ...
            return false;
        }

        private bool IsDelim(char c)
        {
            // ...
            return false;
        }

        private bool IsSign(char c)
        {
            // ...
            return false;
        }

        private int NextDiagram()
        {
            // ...
            return 0;
        }

        // Gibt die Position des als nächstes zu lesenden Zeichens zurück
        public int GetPos()
        {
            // ...
            return 0;
        }

        private int GetToken()
        {
            // ...
            return 0;
        }

        public List<int> GetTokenList()
        {
            // ...
            return new List<int>();
        }
    }
}
