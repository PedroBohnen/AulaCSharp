namespace CarroServico
{
    public class CarroService
    {
        public string ValidarCarro(Carro carro)
        {
            if (carro == null)
            {
                return "Carro deve conter valores.";
            }

            if (carro.Ano < 2010)
            {
                return "O ano do carro deve ser maior que 2010.";
            }

            return "Sucesso";
        }
    }
}
