Comparison xUnit, NUnit, MSTest...

 
NUnit
=====
Visual Studio Extension: NUnit 3 Test Adapter
Install-Package NUnit
using NUnit.Framework;

[TestFixture]
public class Tests {
	[SetUp]
	public void BeforeEach() { }

	[TearDown]
	public void AfterEach() { }

	[Test]
	public void Test1() {
		Assert.That(result, Is.Not.Null);
	}
}

Assert
------
Assert.That(result, Is.EqualTo(someValue));
Assert.Throws<Exception>(() => {throw new Exception();});
Assert.IsInstanceOf<T>(); / IsNotInstanceOf<T>
