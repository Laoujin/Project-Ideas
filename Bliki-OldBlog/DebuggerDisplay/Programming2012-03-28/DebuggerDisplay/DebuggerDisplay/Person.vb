Imports System.ComponentModel

<DebuggerDisplay("{DebuggerDisplay}")> _
Public Class SuperHero
    Inherits Person

    Private _power As String
    Public ReadOnly Property Power() As String
        Get
            Return _power
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal age As Integer, ByVal power As String)
        MyBase.New(name, age)
        _power = power
    End Sub

    Private ReadOnly Property DebuggerDisplay() As String
        Get
            Return "{Name} is not just a human!"
        End Get
    End Property
End Class

<DebuggerDisplay("{DebuggerDisplay")> _
Public Class Person
    Private _name As String
    Private _age As Integer
    Private _contact As ContactDetails

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Age() As Integer
        Get
            Return _age
        End Get
    End Property

    Public ReadOnly Property Contact() As ContactDetails
        Get
            Return _contact
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal age As Integer)
        Me.New(name, age, Nothing)
    End Sub

    Public Sub New(ByVal name As String, ByVal age As Integer, ByVal email As String, ByVal tel As String)
        Me.New(name, age, New ContactDetails(email, tel))
    End Sub

    Public Sub New(ByVal name As String, ByVal age As Integer, ByVal contact As ContactDetails)
        _name = name
        _age = age
        _contact = contact
    End Sub

    Private ReadOnly Property DebuggerDisplay() As String
        Get
            Return "This person is {Name}. {If(Age < 20, ""Young"", Age)}"
        End Get
    End Property
End Class

<DebuggerDisplay("{ToString(),nq} =")> _
Public Enum ContactTypes
    <Description("Unknown address")> _
    Unknown
    <Description("Home address")> _
    Home
    <Description("Work address")> _
    Work
    <Description("Billing address")> _
    Billing
End Enum

Public Class ContactDetails
    Private _email As String
    Private _telephone As String

    Public ReadOnly Property Email() As String
        Get
            Return _email
        End Get
    End Property

    Public ReadOnly Property Telephone() As String
        Get
            Return _telephone
        End Get
    End Property

    Public Sub New(ByVal email As String, ByVal tel As String)
        _email = email
        _telephone = tel
    End Sub
End Class