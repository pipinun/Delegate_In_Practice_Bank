namespace BankAccount;

public delegate void AccountHandler(string message); 
public class Account
{
    private int sum { get; set; } //Переменная для хранения суммы
    // Создаем переменную делегата
    private AccountHandler? taken;
    // через конструктор устанавливается начальная сумма на счете
    public Account(int sum) => this.sum = sum;
    // добавить средства на счет
    public void Add(int sum) => this.sum += sum;
    // Регистрируем делегат
    public void RegisterHandler(AccountHandler del)
    {
        taken = del;
    }
    // взять деньги с счета
    public void Take(int sum)
    {
        // берем деньги, если на счете достаточно средств
        if (this.sum >= sum)
        {
            this.sum -= sum;
            taken?.Invoke("Со счета списано");
        }
        else
        {
            taken?.Invoke($"не достаточно средств {this.sum}$");
        }
    }
}