using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form1
{
    public class Presenter
    {
        Modal model = null;           //посилання на model
        MainWindow mainWindow = null; // та mainWindow
        public Presenter(MainWindow mainWindow)
        {
            model = new Modal();
            this.mainWindow = mainWindow;
            this.mainWindow.ToHrnEvent += MainWindow_toHrn; // підписує відповідну подію на відповідний метод-оброблювач
        }
        //метод-оброблювач
        private void MainWindow_toHrn(object sender, EventArgs e)
        {
            if (mainWindow.textbox3.Text.ToUpper() == "UAH" && mainWindow.textbox4.Text.ToUpper() == "USD")
            {
                string varible = model.ConvertToHrn(Convert.ToDecimal(mainWindow.textBox1.Text)); // бере з моделі метод ConvertToHrn і в якості параметра передають конвертовану строку з mainWindow
                mainWindow.textBox2.Text = varible;  // метод ConvertToHrn повертає якесь значення varible яке ми записуємо в textBox2       
            }
            else if (mainWindow.textbox3.Text.ToUpper() == "USD" && mainWindow.textbox4.Text.ToUpper() == "UAH")
            {
                string varible = model.ConvertToUsd(Convert.ToDecimal(mainWindow.textBox1.Text)); // бере з моделі метод ConvertToHrn і в якості параметра передають конвертовану строку з mainWindow
                mainWindow.textBox2.Text = varible;  // метод ConvertToHrn повертає якесь значення varible яке ми записуємо в textBox2       
            }
            else mainWindow.textBox2.Text = "Вибачте за тимчасові не зручності, але дана функція не доступна на даний час. Команда наших розробників вже працює над цим";
        }
    }
}