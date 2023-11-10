
namespace ContosoExpenses.Messages;

public class CloseWindowMessage
{
    public CloseWindowMessage(object sender)
    {
        Sender = sender;
    }

    public object Sender { get; }
}
