using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaProves;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace ProvesBibliotecaFrases
{
    [TestClass]
    public class UnitTest1
    {
        BibliotecaFrases biblioteca = new BibliotecaFrases();
        List<string> llResultat = new List<string>();
        String filename1, pathfilename1, filename2, pathfilename2;


        [TestMethod]
        public void ParaulesRepetides()
        {
            String frase1 = "ei que passa tronku";
            String frase2 = "no passa res tronku";

            llResultat.Add("passa");
            llResultat.Add("tronku");
           
            CollectionAssert.AreEqual(llResultat, biblioteca.ParaulesRepetides(frase1, frase2));
        }

        [TestMethod]
        public void ParaulesNoRepetides()
        {
            String frase1 = "hola me llamo carlos";
            String frase2 = "el carlos me ha llamado";

            //El orden debe de ser el mismo, primero las palabras de la frase 2 y despues las de la 1.
            //Si no, compara y como no le da lo mismo, peta.
            llResultat.Add("el");
            llResultat.Add("ha");
            llResultat.Add("llamado");
            llResultat.Add("hola");
            llResultat.Add("llamo");

            CollectionAssert.AreEquivalent(llResultat, biblioteca.ParaulesNoRepetides(frase1, frase2));
        }

        [TestMethod]
        public void paraulesMesRepetides()
        {   
            String frase1 = "hola carlos hola";
            String frase2 = "hola jaume adeu carlos hola";          

            string[] resultat = new string[] { "hola", "carlos" };

            llResultat.AddRange(resultat);

            CollectionAssert.AreEquivalent(llResultat, biblioteca.ParaulesMesRepetides(frase1, frase2));
        }

        [TestMethod]
        public void ParaulesRepetidesFile()
        {
            //Nombre de los archivos
            filename1 = "file1.txt";
            filename2 = "file2.txt";

            //Ruta de los ficheros
            pathfilename1 = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename1));
            pathfilename2 = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename2));

            //~FOPEN --> ABRIR FICHERO
            StreamReader f1 = new StreamReader(pathfilename1, System.Text.Encoding.Default);
            StreamReader f2 = new StreamReader(pathfilename2, System.Text.Encoding.Default);

            llResultat.Add("hola");
            llResultat.Add("me");
            llResultat.Add("carlos");

            CollectionAssert.AreEqual(llResultat, biblioteca.ParaulesRepetidesFile(ref f1, ref f2));
        }

        [TestMethod]
        public void ParaulesNoRepetidesFile()
        {
            filename1 = "file1.txt";
            filename2 = "file2.txt";

            pathfilename1 = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename1));
            pathfilename2 = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename2));

            StreamReader f1 = new StreamReader(pathfilename1, System.Text.Encoding.Default);
            StreamReader f2 = new StreamReader(pathfilename2, System.Text.Encoding.Default);

            llResultat.Add("llaman");
            llResultat.Add("llamo");

            CollectionAssert.AreEquivalent(llResultat, biblioteca.ParaulesNoRepetidesFile(ref f1, ref f2));
        }

        [TestMethod]
        public void ParaulesMesRepetidesFile()
        {
            filename1 = "file1mesRepetides.txt";
            filename2 = "file2mesRepetides.txt";

            pathfilename1 = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename1));
            pathfilename2 = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, string.Concat(@"..\..\..\", filename2));

            StreamReader f1 = new StreamReader(pathfilename1, System.Text.Encoding.Default);
            StreamReader f2 = new StreamReader(pathfilename2, System.Text.Encoding.Default);

            llResultat.Clear();
            llResultat.Add("llamo");
            llResultat.Add("hola");
            llResultat.Add("carlos");
            llResultat.Add("me");

            CollectionAssert.AreEquivalent(llResultat, biblioteca.ParaulesMesRepetidesFile(ref f1, ref f2));
        }
    }
}
