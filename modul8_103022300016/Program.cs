
namespace modul8_103022300016
{
    class Program
    {
        public static void Main(String[] args)
        {
            BankConfig bankConfig = new BankConfig();
            
            Console.WriteLine("Aplikasi Bank Holo");
            Console.WriteLine("====================================");
            Console.WriteLine("Type a language (id/en)");
            string pilihanBahasa = Console.ReadLine();
            if (pilihanBahasa == "id")
            {
                bankConfig.ubahBahasa();
                Console.Write("Masukkan jumlah uang yang akan di transfer: ");
                int uang = Convert.ToInt32(Console.ReadLine());

                if (uang < bankConfig.config.transfer.threshold)
                {
                    Console.WriteLine($"Biaya transfer: {bankConfig.config.transfer.low_fee} dan Total Biaya = {uang + bankConfig.config.transfer.low_fee}");
                }
                else
                {
                    Console.WriteLine($"Biaya transfer: {bankConfig.config.transfer.high_fee} dan Total Biaya = {uang + bankConfig.config.transfer.high_fee}");
                }

                Console.WriteLine("Pilih metode transfer: ");
                for (int i = 0; i < bankConfig.config.methods.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + bankConfig.config.methods[i]);
                }
                Console.Write("Pilih: ");
                int metodeTransaksi = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Ketik {bankConfig.config.confirmation.id} untuk mengkonfirmasi transaksi");
                string konfirmasi = Console.ReadLine();

                if (konfirmasi != bankConfig.config.confirmation.id)
                {
                    Console.WriteLine("Transfer dibatalkan");
                    return;
                }

                Console.WriteLine("Proses Tranasaksi Berhasil");
            }
            else if (pilihanBahasa == (bankConfig.config.lang))
            {
                bankConfig.ubahBahasa();
                Console.Write("Please insert the amount of money to transfer: ");
                int uang = Convert.ToInt32(Console.ReadLine());

                if (uang < bankConfig.config.transfer.threshold)
                {
                    Console.WriteLine($"Transfer fee: {bankConfig.config.transfer.low_fee} and Total Amount = {uang + bankConfig.config.transfer.low_fee}");
                }
                else
                {
                    Console.WriteLine($"Transfer fee: {bankConfig.config.transfer.high_fee} and Total Amount = {uang + bankConfig.config.transfer.high_fee}");
                }
                Console.WriteLine("Select transfer method: ");
                for (int i = 0; i < bankConfig.config.methods.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + bankConfig.config.methods[i]);
                }

                Console.Write("Choose: ");
                int metodeTransaksi = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Type {bankConfig.config.confirmation.en} to confirm transaction");
                string konfirmasi = Console.ReadLine();

                if (konfirmasi != bankConfig.config.confirmation.en)
                {
                    Console.WriteLine("Transfer is cancelled");
                    return;
                }

                Console.WriteLine("The Transfer is Completed");
            }
        }
    }
}