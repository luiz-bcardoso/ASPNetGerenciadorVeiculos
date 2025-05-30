namespace ASPNetGerenciadorVeiculos.Models
{
    public class Veiculo
    {
        private int _id;
        private string _nome;
        private string _modelo;
        private string _marca;
        private string _renavam;
        private int _anoFabricacao;
        private int _anoModelo;
        private string _dirFoto;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Renavam { get => _renavam; set => _renavam = value; }
        public int AnoFabricacao { get => _anoFabricacao; set => _anoFabricacao = value; }
        public int AnoModelo { get => _anoModelo; set => _anoModelo = value; }
        public string DirFoto { get => _dirFoto; set => _dirFoto = value; }

        public override string ToString()
        {
            return $"{Id};{Nome};{Modelo};{Marca};{Renavam};{AnoFabricacao};{AnoModelo};{DirFoto}";
        }
    }
}
