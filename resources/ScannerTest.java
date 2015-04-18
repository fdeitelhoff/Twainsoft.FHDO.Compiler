public class ScannerTest {

  public static void printToken (int token) {
	switch (token) {
	  case Scanner.OPEN:    System.out.print(" ( ");
	                        break;
	  case Scanner.CLOSE:   System.out.print(" ) ");
	                        break;
	  case Scanner.INTEGER: System.out.print(" INTEGER ");
			                break;
  	  case Scanner.REAL:    System.out.print(" REAL ");
	                        break;
      default:
       	System.out.print ("Unbekannter Token " + token);
	}
  }

  public static void main(String[] args) {

    String[] inputs = {"()  \n349 )4.1E1(", "\t-349 )  ( +598", "()  \n+555 )+-222", ") \n-566  287)<",
    	               "(  \n5.66 M)287)", "(  \n  \t-256.77E-12) "};
    for (String strBuffer : inputs) {
		Scanner scanner = new Scanner(strBuffer);
		// TODO
		// Scannen starten und erkannte Token ausgeben
    }
  }
}

