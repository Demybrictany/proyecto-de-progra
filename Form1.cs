using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text.Json;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Form1 : Form
    {
        public List<FACTURA> factura = new List<FACTURA>(); //Hay datos y algunas cosas conectadas a SQL que ya no se usaron
        public List<BOMBAS> bombas = new List<BOMBAS>();
        private Timer timer;
        private int duration;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            // Inicializa y configura el Timer
            timer = new Timer();
            timer.Interval = 1000; // Intervalo de 1 segundo
            timer.Tick += Timer_Tick;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            label6.Text = fechaActual.ToString("dd/MM/yyyy");//Se establece el tiempo en las labels

            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lógica para manejar el temporizador y actualizar textBox2
            if (textBox4.Text == "1")
            {
                serialPort1.Open();
                serialPort1.Write("1");
                serialPort1.Close();
                textBox6.Text = "Encendiendo Bomba 1";

                if (textBox3.Text == "FULL")
                {
                    serialPort1.Open();
                    serialPort1.Write("1");
                    serialPort1.Close();
                    textBox6.Text = "Encendiendo Bomba 1 en auto llenado";
                }
                else
                {
                    // Iniciar el temporizador solo si no es "FULL"
                    if (int.TryParse(textBox3.Text, out int seconds))
                    {
                        duration = seconds;
                        StartTimer();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, introduce un número válido en el tiempo de duración.");
                        return;
                    }
                }

                MessageBox.Show("Datos procesados");

                string nombre = textBox1.Text;
                int nit = Convert.ToInt32(textBox2.Text);
                string hora = label5.Text;
                string fecha = label6.Text;

                FACTURA facturas = new FACTURA(nombre, nit, fecha, hora);//
                factura.Add(facturas);
                decimal galones = textBox3.Text == "FULL" ? 0 : Convert.ToDecimal(textBox3.Text);
                BOMBAS bomba = new BOMBAS(textBox4.Text, galones);
                bombas.Add(bomba);

                var data = new
                {
                    Nombre = nombre, //Cadena de json con los datos del cliente
                    NIT = nit,
                    Hora = hora,
                    Fecha = fecha,
                };
                string json = JsonSerializer.Serialize(data);


                var data1 = new
                {
                    Bomba = textBox4.Text, //Cadena de datos de la gasolinera
                    Galones = galones
                };
                string json2 = JsonSerializer.Serialize(data1);
                listBox1.Items.Add(json + json2); //unir las 2 cadenas
                textBox5.Text = json2;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                string carpeta = "C:\\GasolineraUNO\\Facturas";
                string ruta = Path.Combine(carpeta, nombre + ".txt");//guardar los datos en la carpeta
                File.WriteAllText(ruta, json + json2);
            }
            else if (textBox4.Text == "2")
            {
                serialPort2.Open();
                serialPort2.Write("2");
                serialPort2.Close();
                textBox6.Text = "Encendiendo Bomba 2";

                if (textBox3.Text == "FULL")
                {
                    serialPort2.Open();
                    serialPort2.Write("2");
                    serialPort2.Close();
                    textBox6.Text = "Encendiendo Bomba 2 en auto llenado";
                }
                else
                {
                    // Iniciar el temporizador solo si no es "FULL"
                    if (int.TryParse(textBox3.Text, out int seconds))
                    {
                        duration = seconds;
                        StartTimer();///aqui
                    }
                    else
                    {
                        MessageBox.Show("Por favor, introduce un número válido en el tiempo de duración.");
                        return;
                    }
                }

                MessageBox.Show("Datos procesados");

                string nombre = textBox1.Text;
                int nit = Convert.ToInt32(textBox2.Text);
                string hora = label5.Text;
                string fecha = label6.Text;

                FACTURA facturas = new FACTURA(nombre, nit, fecha, hora);
                factura.Add(facturas);
                decimal galones = textBox3.Text == "FULL" ? 0 : Convert.ToDecimal(textBox3.Text);
                BOMBAS bomba = new BOMBAS(textBox4.Text, galones);
                bombas.Add(bomba);

                var data = new
                {
                    Nombre = nombre,
                    NIT = nit,
                    Hora = hora,
                    Fecha = fecha,
                };
                string json = JsonSerializer.Serialize(data);

                var data1 = new
                {
                    Bomba = textBox4.Text,
                    Galones = galones
                };
                string json2 = JsonSerializer.Serialize(data1);
                listBox1.Items.Add(json + json2);
                textBox5.Text = json2;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                string carpeta = "C:\\GasolineraUNO\\Facturas";
                string ruta = Path.Combine(carpeta, nombre + ".txt");
                File.WriteAllText(ruta, json + json2);
            }

            else if (textBox4.Text == "3") //simulando que hay 4 bombas, en fisico solo van a haber 2. Asi que seran: 1 bomba impar y 1 bomba par
            {
                serialPort1.Open();
                serialPort1.Write("1");
                serialPort1.Close();
                textBox6.Text = "Encendiendo Bomba 3";

                if (textBox3.Text == "FULL")
                {
                    serialPort1.Open();
                    serialPort1.Write("1");
                    serialPort1.Close();
                    textBox6.Text = "Encendiendo Bomba 3 en auto llenado";
                }
                else
                {
                    // Iniciar el temporizador solo si no es "FULL"
                    if (int.TryParse(textBox3.Text, out int seconds))
                    {
                        duration = seconds;
                        StartTimer();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, introduce un número válido en el tiempo de duración.");
                        return;
                    }
                }

                MessageBox.Show("Datos procesados");

                string nombre = textBox1.Text;
                int nit = Convert.ToInt32(textBox2.Text);
                string hora = label5.Text;
                string fecha = label6.Text;

                FACTURA facturas = new FACTURA(nombre, nit, fecha, hora);
                factura.Add(facturas);
                decimal galones = textBox3.Text == "FULL" ? 0 : Convert.ToDecimal(textBox3.Text);
                BOMBAS bomba = new BOMBAS(textBox4.Text, galones);
                bombas.Add(bomba);

                var data = new
                {
                    Nombre = nombre,
                    NIT = nit,
                    Hora = hora,
                    Fecha = fecha,
                };
                string json = JsonSerializer.Serialize(data);

                var data1 = new
                {
                    Bomba = textBox4.Text,
                    Galones = galones
                };
                string json2 = JsonSerializer.Serialize(data1);
                listBox1.Items.Add(json + json2);
                textBox5.Text = json2;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                string carpeta = "C:\\GasolineraUNO\\Facturas";
                string ruta = Path.Combine(carpeta, nombre + ".txt");
                File.WriteAllText(ruta, json + json2);
            }

            else if (textBox4.Text == "4")
            {
                serialPort2.Open();
                serialPort2.Write("2");
                serialPort2.Close();
                textBox6.Text = "Encendiendo Bomba 4";

                if (textBox3.Text == "FULL")
                {
                    serialPort2.Open();
                    serialPort2.Write("2");
                    serialPort2.Close();
                    textBox6.Text = "Encendiendo Bomba 4 en auto llenado";
                }
                else
                {
                    // Iniciar el temporizador solo si no es "FULL"
                    if (int.TryParse(textBox3.Text, out int seconds))
                    {
                        duration = seconds;
                        StartTimer();///aqui
                    }
                    else
                    {
                        MessageBox.Show("Por favor, introduce un número válido en el tiempo de duración.");
                        return;
                    }
                }

                MessageBox.Show("Datos procesados");

                string nombre = textBox1.Text;
                int nit = Convert.ToInt32(textBox2.Text);
                string hora = label5.Text;
                string fecha = label6.Text;

                FACTURA facturas = new FACTURA(nombre, nit, fecha, hora);
                factura.Add(facturas);
                decimal galones = textBox3.Text == "FULL" ? 0 : Convert.ToDecimal(textBox3.Text);
                BOMBAS bomba = new BOMBAS(textBox4.Text, galones);
                bombas.Add(bomba);

                var data = new
                {
                    Nombre = nombre,
                    NIT = nit,
                    Hora = hora,
                    Fecha = fecha,
                };
                string json = JsonSerializer.Serialize(data);

                var data1 = new
                {
                    Bomba = textBox4.Text,
                    Galones = galones
                };
                string json2 = JsonSerializer.Serialize(data1);
                listBox1.Items.Add(json + json2);
                textBox5.Text = json2;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                string carpeta = "C:\\GasolineraUNO\\Facturas";
                string ruta = Path.Combine(carpeta, nombre + ".txt");
                File.WriteAllText(ruta, json + json2);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (duration > 0)
            {
                duration--;
            }
            else
            {
                timer.Stop();

                textBox6.Text = "Apagado";

                serialPort1.Open();
                serialPort1.Write("0");
                serialPort1.Close();
            }
            if (duration > 0)
            {
                duration--;
            }
            else
            {
                timer.Stop();

                textBox6.Text = "Apagado";

                serialPort1.Open();
                serialPort1.Write("0");
                serialPort1.Close();

                serialPort2.Open();
                serialPort2.Write("0");
                serialPort2.Close();
            }
        }

        private void StartTimer()
        {
            timer.Stop();
            timer.Start();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Este evento ya no es necesario para configurar la duración del temporizador
            // La duración se configurará al hacer clic en el botón
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Este evento ya no es necesario para configurar la duración del temporizador
            // La duración se configurará al hacer clic en el botón
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string[] PortList = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(PortList);
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            string[] PortList = SerialPort.GetPortNames();
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(PortList);
        }

        private void enableopt_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text; //definir los puertos de conexion de un arduino
                serialPort2.PortName = comboBox2.Text;

                MessageBox.Show("Conexion Establecida con el Arduino");

                groupBox1.Enabled = true;
               

                enableopt.Enabled = false;
                endopt.Enabled = true;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void endopt_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();

                    MessageBox.Show("Se Desconecto el Arduino 1"); //Finalizar operaciones con los arduinos

                    groupBox1.Enabled = false;
                    

                    enableopt.Enabled = true;
                    endopt.Enabled = false;
                }

                if (serialPort2.IsOpen)
                {
                    serialPort1.Close();

                    MessageBox.Show("Se Desconecto el Arduino 2");

                    groupBox1.Enabled = false;


                    enableopt.Enabled = true;
                    endopt.Enabled = false;
                }


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
