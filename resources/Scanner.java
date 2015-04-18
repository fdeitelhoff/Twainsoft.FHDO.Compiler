import java.util.*;

public class Scanner {

  // Definition der Token
  final static int OPEN = 1000;
  // weitere Token ...

  // Fehler beim Scannen
  final static int ERROR = 2000;

  // Kein Zustandsdiagramm passend
  // Folgezustand dann ERROR_STATE
  final static int ERROR_STATE = -1;

  // Puffer fuer Eingabezeichenfolge
  private char[] buffer;

  // Positionen in Puffer
  private int pos = 0;
  private int start_pos = 0;

  // Zustaende
  private int state;
  private int start_state;

  public Scanner(String strBuffer) {
  	// ...
  }

  private char nextchar() throws ArrayIndexOutOfBoundsException {
     // ...
  }

  private void stepback() {
     // ...
  }

  private boolean isdigit(char c) {
     // ...
  }

  private boolean isdelim(char c) {
     // ...
  }

  private boolean issign(char c) {
     // ...
  }

  private int next_diagram() {
     // ...
  }

  // Gibt die Position des als nächstes zu lesenden Zeichens zurück
  public int getpos() {
     // ...
  }

  private int gettoken() {
     // ...
  }

  public List<Integer> getTokenlist() {
  	 // ...
  }

}
