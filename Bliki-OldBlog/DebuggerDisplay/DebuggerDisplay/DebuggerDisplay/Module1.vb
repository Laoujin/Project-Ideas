Module Module1
    Sub Main()

        ' Initialize some dummy data
        Dim steven As New Person("Steven", 30, "steven@megafarm.com", "0476 40 40 40")
        Dim jemel As New Person("Jemel", 20, "jemel@megafarm.com", "0477 30 30 30")
        Dim hans As New Person("Hans", 10, "hans@megafarm.com", "0496 20 20 20")
        Dim people = New Person() {steven, jemel, hans}

        Dim superman As New SuperHero("Superman", 20, "Everything")

        Dim simpleStringDict As New Dictionary(Of DateTime, String)
        Dim startDate = DateTime.Now
        For i As Integer = 1 To 5
            simpleStringDict.Add(startDate.AddDays(i), "Value" + i.ToString())
        Next

        Dim notSoSimpleDict As New Dictionary(Of String, Person)
        notSoSimpleDict.Add("Key1", steven)
        notSoSimpleDict.Add("Key2", jemel)
        notSoSimpleDict.Add("Key3", hans)

        Dim simpleList As New List(Of Person)
        simpleList.AddRange(people)

        Dim home As ContactTypes = ContactTypes.Billing

        Dim x = home.ToString()
        Dim z = CInt([Enum].Parse(GetType(ContactTypes), x))

        Dim strB As New Text.StringBuilder()
        strB.Append("testing123")

        Dim someTest As New Test()

        Dim percentage As String = 0.445451541.ToString("p")

        ' Put breakpoint to view custom class in debug mode
        Dim stopme As Integer = 0
    End Sub
End Module

'<DebuggerDisplay("MemoryUsage=\{{Length,nq} / {Capacity,nq}\} ({(Length / Capacity).ToString(""p""),nq})")> _

<DebuggerDisplay("MemoryUsage=\{{Length,nq} / {Capacity,nq}\} ({Math.Round(Length / Capacity * 10000) / 100,nq}%)")> _
Public Class Test



    Private _length As Integer
    Public Property Length() As Integer
        Get
            Return _length
        End Get
        Set(ByVal value As Integer)
            _length = value
        End Set
    End Property


    Private _a As Integer
    Public Property Capacity() As Integer
        Get
            Return _a
        End Get
        Set(ByVal value As Integer)
            _a = value
        End Set
    End Property


    Public Sub New()
        _a = 15
        _length = 7
    End Sub
End Class
