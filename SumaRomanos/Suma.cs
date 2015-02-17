using System;
namespace SumaRomanos
{
	public class Suma
	{
		
		public int primerNumero;
		public int segundoNumero;
		public int totalNumeros;
		public int potenciaDiez;
		public string romano;
		public string[,] notacionRomana= new string[4,2] {{"I","V"},{"X","L"},{"C","D"},{"M","A"}};

		public Suma ()
		{
			this.primerNumero = int.Parse(Console.ReadLine());
			this.segundoNumero = int.Parse(Console.ReadLine());
			this.totalNumeros = this.primerNumero + this.segundoNumero;
			this.potenciaDiez = calcularPotenciaDiez();
			this.romano = "";
			sacarRomano ();
		}

		public int calcularPotenciaDiez(){
			int potenciaDiez = 0;
			float numeroParcial = totalNumeros;
			while ((numeroParcial / 10) >= 1) {
				numeroParcial/=10;
				potenciaDiez++;
			}
			return potenciaDiez;
		}


		void sacarRomano(){
			int numeroParcial=0;
			int numerosAnteriores=0;
			for(int i=this.potenciaDiez; i>=0;i--){

				numeroParcial= (int)(this.totalNumeros/(Math.Pow(10,i)) - numerosAnteriores);
				numerosAnteriores=((int) ((numeroParcial+numerosAnteriores)*10));


				this.romano+=escogerLetras(numeroParcial,i);
				
			};

			Console.WriteLine (romano);

		}

		public string escogerLetras(int numero, int indice){
			string letras = "";



			if (numero > 0 && numero <= 3) {

				for(int k = 1; k<=numero;k++){
					letras+= this.notacionRomana[indice,0];
				}

			} else if (numero == 4) {

				letras+= (this.notacionRomana[indice,0] + this.notacionRomana[indice,1]);

			} else if (numero > 4 && numero <= 8) {

				letras+= this.notacionRomana[indice,1];

				for(int k = 6; k<=numero;k++){
					letras+= this.notacionRomana[indice,0];
				}

			} else if (numero == 9) {
					letras+= (this.notacionRomana[indice,0] + this.notacionRomana[indice+1,0]);
			} else {

			}

			return letras;
			
		}



	}
}

