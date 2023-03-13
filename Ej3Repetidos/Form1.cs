namespace Ej3Repetidos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Moda.Text))
            {
                lblModa.Text = "El cuadro de texto está vacío";
                return;
            }
            
            string[] valores = txt_Moda.Text.Split(',');

            
            int[] numeros = Array.ConvertAll(valores, int.Parse);

          
            Dictionary<int, int> frecuencias = new Dictionary<int, int>();
            int maxFrecuencia = 0;

            foreach (int numero in numeros)
            {
                if (frecuencias.ContainsKey(numero))
                {
                    frecuencias[numero]++;
                }
                else
                {
                    frecuencias[numero] = 1;
                }

                if (frecuencias[numero] > maxFrecuencia)
                {
                    maxFrecuencia = frecuencias[numero];
                }
            }

            List<int> moda = new List<int>();

            foreach (KeyValuePair<int, int> kvp in frecuencias)
            {
                if (kvp.Value == maxFrecuencia)
                {
                    moda.Add(kvp.Key);
                }
            }

           
            if (moda.Count == 1)
            {
                lblModa.Text = $"La moda es: {moda[0]}";
            }
            else if (moda.Count > 1)
            {
                lblModa.Text = "Hay varias modas: " + string.Join(", ", moda);
            }


        }
    }
}