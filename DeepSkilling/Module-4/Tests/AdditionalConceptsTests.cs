using Moq;
using NUnit.Framework;

// ---------------------------------------------------------------------------
// 1. Parameterized tests, testing collections/strings, testing exceptions
// ---------------------------------------------------------------------------
public class CalculatorTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void Setup() => _calculator = new Calculator();

    // Parameterized test using TestCase
    [TestCase(2, 3, 5)]
    [TestCase(-1, 1, 0)]
    [TestCase(0, 0, 0)]
    public void Add_ReturnsExpectedSum(int a, int b, int expected)
    {
        Assert.That(_calculator.Add(a, b), Is.EqualTo(expected));
    }

    // Testing a method that throws an exception
    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
    }

    // Testing a collection return type
    [Test]
    public void GetEvenNumbers_ReturnsOnlyEvens()
    {
        var result = _calculator.GetEvenNumbers(new[] { 1, 2, 3, 4, 5, 6 });
        Assert.That(result, Is.EqualTo(new[] { 2, 4, 6 }));
    }

    // Testing string manipulation
    [TestCase("hello", "HELLO")]
    [TestCase("World", "WORLD")]
    public void ToUpperTrimmed_ReturnsUppercaseTrimmedString(string input, string expected)
    {
        Assert.That(_calculator.ToUpperTrimmed($"  {input}  "), Is.EqualTo(expected));
    }
}

public class Calculator
{
    public int Add(int a, int b) => a + b;

    public int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }

    public IEnumerable<int> GetEvenNumbers(IEnumerable<int> numbers) =>
        numbers.Where(n => n % 2 == 0);

    public string ToUpperTrimmed(string input) => input.Trim().ToUpperInvariant();
}

// ---------------------------------------------------------------------------
// 2. Dependency Injection via constructor, property, and method parameters
//    + mocking each style with Moq
// ---------------------------------------------------------------------------
public interface INotifier
{
    void Notify(string message);
}

// Constructor injection
public class OrderProcessor
{
    private readonly INotifier _notifier;
    public OrderProcessor(INotifier notifier) => _notifier = notifier;

    public void ProcessOrder(string orderId)
    {
        _notifier.Notify($"Order {orderId} processed.");
    }
}

// Property injection
public class ReportGenerator
{
    public INotifier? Notifier { get; set; }

    public void GenerateReport(string reportName)
    {
        Notifier?.Notify($"Report {reportName} generated.");
    }
}

// Method parameter injection
public class InvoiceService
{
    public void SendInvoice(INotifier notifier, string invoiceId)
    {
        notifier.Notify($"Invoice {invoiceId} sent.");
    }
}

public class DependencyInjectionStylesTests
{
    [Test]
    public void ConstructorInjection_CallsNotify()
    {
        var mockNotifier = new Mock<INotifier>();
        var processor = new OrderProcessor(mockNotifier.Object);

        processor.ProcessOrder("ORD-1");

        mockNotifier.Verify(n => n.Notify("Order ORD-1 processed."), Times.Once);
    }

    [Test]
    public void PropertyInjection_CallsNotify()
    {
        var mockNotifier = new Mock<INotifier>();
        var generator = new ReportGenerator { Notifier = mockNotifier.Object };

        generator.GenerateReport("Sales-Q1");

        mockNotifier.Verify(n => n.Notify("Report Sales-Q1 generated."), Times.Once);
    }

    [Test]
    public void MethodParameterInjection_CallsNotify()
    {
        var mockNotifier = new Mock<INotifier>();
        var invoiceService = new InvoiceService();

        invoiceService.SendInvoice(mockNotifier.Object, "INV-99");

        mockNotifier.Verify(n => n.Notify("Invoice INV-99 sent."), Times.Once);
    }

    // Ignoring a test (with reason) — Ignoring Tests sub-topic
    [Test]
    [Ignore("Not implemented yet — placeholder for future SMS notifier feature")]
    public void SmsNotifier_NotYetImplemented()
    {
        Assert.Fail();
    }
}

/*
 * Code Coverage:
 * Run `dotnet test --collect:"XPlat Code Coverage"` (requires coverlet.collector package)
 * to generate a coverage report you can view with a tool like ReportGenerator.
 */
