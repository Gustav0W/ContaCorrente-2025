namespace ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public List<string> movimentacoes;

        public ContaCorrente(int numero, double saldoInicial, double limite)
        {
            Numero = numero;
            Saldo = saldoInicial;
            Limite = limite;
            movimentacoes = new List<string>();
        }

        public bool Sacar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Não tem como sacar valores negativos.");
                return false;
            }
            if (Saldo + Limite >= valor)
            {
                Saldo -= valor;
                movimentacoes.Add($"Saque: -R${valor:F2}");
                Console.WriteLine($"Você sacou R${valor:F2}");
                return true;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                movimentacoes.Add($"Depósito: +R${valor:F2}");
                Console.WriteLine($"Você depositou R${valor:F2}");
            }
            else
            {
                Console.WriteLine("Valor inválido para depósito.");
            }
        }

        public bool TransferirPara(ContaCorrente destino, double valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                movimentacoes.Add($"O valor enviado foi de: -R${valor:F2} para a conta {destino.Numero}");
                destino.movimentacoes.Add($"Você recebeu o valor de: +R${valor:F2} da conta {Numero}");
                Console.WriteLine($"A transferência de R${valor:F2} para a conta {destino.Numero} foi realizada com sucesso!");
                return true;
            }
            return false;
        }

        public void ExibirExtrato()
        {
            Console.WriteLine($"\nExtrato da conta {Numero}:");
            foreach (var item in movimentacoes)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Saldo atual: R${Saldo:F2}\n");
        }

        public void MostrarSaldoFinal()
        {
            Console.WriteLine($"Saldo final da conta {Numero}: R${Saldo:F2}");
        }
    }
}

 


