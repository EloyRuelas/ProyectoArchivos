using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Archivos
{
   

    public partial class Form1 : Form
    {
        public long cabecera;
        int n;

        public Form1()
        {
            InitializeComponent();
            cabecera = -1;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crea objeto `FileStream` para referenciar un archivo binario -ArchivoBinario.bin-:
            using (FileStream fs = new FileStream("DiccionarioDatos.dd", FileMode.Create))
            {
                // Escritura sobre el archivo binario `ArchivoBinario.bin` usando un 
                // objeto de la clase `BinaryWriter`:
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    // Escritura de datos de naturaleza primitiva:
                    bw.Write(cabecera);
                    
                }
            }
            Console.WriteLine("Los datos han sido escritos en el archivo `ArchivoBinario.dd`.");


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Apertura del archivo `ArchivoBinario.bin` en modo lectura:
            using (FileStream fs = new FileStream("ArchivoBinario.dd", FileMode.Open))
            {
                // Muestra la información tal cual está escrita en el archivo binario:
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine(sr.ReadLine());
                    Console.WriteLine();

                    // Lectura y conversión de los datos binarios en el tipo de 
                    // correspondiente:

                    // Posiciona el cursor desde se iniciara la lectura del 
                    // archivo `ArchivoBinario`:
                    fs.Position = 0;

                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        Console.WriteLine(br.ReadDecimal());
                        Console.WriteLine(br.ReadString());
                        Console.WriteLine(br.ReadString());
                        Console.WriteLine(br.ReadChar());
                    }
                }
            }
        }

        public void tamaño()
        {
            var dd = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Debug\ArchivoBinario.dd");
            FileInfo file = new FileInfo(dd);

            long valor = file.Length;
            MessageBox.Show(Convert.ToString(valor));
        }

        private void tamañoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tamaño();
            //hola
            
        }

        private void atributosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaAtributos a = new VentanaAtributos();
            this.Hide();
            a.ShowDialog();
            this.Show();
            
        }

        //Agregar entidades
        private void button1_Click(object sender, EventArgs e)
        {
            //Agregar una fila
            int n = dGVE.Rows.Add();

            //Agregamos la informacion
            dGVE.Rows[n].Cells[0].Value = textBox1.Text;

            //Limpiar texto
            textBox1.Clear();
        }

        private void dGVE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = dGVE.CurrentRow.Index;

            if(n!= -1)
            {
                textBox1.Text = (string)dGVE.Rows[n].Cells[0].Value;
                
            }
        }

        //Eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            if(n!=-1)
            {
                dGVE.Rows.RemoveAt(n);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = dGVE.CurrentRow.Index;

            //Agregamos la informacion
            dGVE.Rows[n].Cells[0].Value = textBox1.Text;

            //Limpiar texto
            textBox1.Clear();
        }
    }
}
