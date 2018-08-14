using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MotosikletBuilder motosikletBuilder = new YamahaMotosikletBuilder();
            MotosikletDirector motosikletDirector = new MotosikletDirector(motosikletBuilder);
            Console.WriteLine(motosikletBuilder.motosiklet.Marka + " " + motosikletBuilder.motosiklet.Model);

            Console.ReadKey();
        }
    }

    public class Motosiklet
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Motor { get; set; }
        public string Lastik { get; set; }
    }
    abstract class MotosikletBuilder
    {
        public abstract void MotorTak();
        public abstract void LastikTak();
        protected Motosiklet _motosiklet;
        public Motosiklet motosiklet
        {
            get { return _motosiklet; }
        }
    }
    class YamahaMotosikletBuilder : MotosikletBuilder
    {
        public YamahaMotosikletBuilder()
        {
            _motosiklet = new Motosiklet
            {
                Marka = "Yamaha",
                Model = "R25"
            };
        }

        public override void LastikTak()
        {
            _motosiklet.Lastik = "160'lık cadde lastiği";
        }

        public override void MotorTak()
        {
            _motosiklet.Motor = "250 CC";
        }
    }

    class HondaMotosikletBuilder : MotosikletBuilder
    {
        public HondaMotosikletBuilder()
        {
            _motosiklet = new Motosiklet
            {
                Marka = "Honda",
                Model = "CRF"
            };
        }

        public override void LastikTak()
        {
            _motosiklet.Lastik = "140'lık offroad lastiği";
        }

        public override void MotorTak()
        {
            _motosiklet.Motor = "450 CC";
        }
    }
    class MotosikletDirector
    {
        public MotosikletDirector(MotosikletBuilder builder)
        {
            builder.MotorTak();
            builder.LastikTak();
        }
    }
}
