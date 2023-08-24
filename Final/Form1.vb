Imports System.Configuration

Public Class Form1

    Dim NormalSales() As String = IO.File.ReadAllLines("NormalSales.txt")
    Dim BloomingtonSales() As String = IO.File.ReadAllLines("BloomingtonSales.txt")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Sub that reports on which day the sum of sales from both stores was the most and what was that amount

        CalculateMaxSales()
        AverageSales()
        BloomingtonLeastSales()

    End Sub

    Sub CalculateMaxSales()

        ' Clear the list box

        ListBox1.Items.Clear()

        'Declaring variables for the sum of sales and the day 

        Dim MaxSales As Double
        Dim MaxSalesDay As String = ""


        'Since both stores have the same days, we are ooping through NormalSales only to get the length

        For i As Integer = 0 To NormalSales.Count - 1

            'Calculating 

            Dim NormalSalesDay As Double = CDbl(NormalSales(i))
            Dim BloomingtonSalesDay As Double = CDbl(BloomingtonSales(i))

            Dim TotalSalesDay As Double = NormalSalesDay + BloomingtonSalesDay


            If TotalSalesDay > MaxSales Then
                MaxSales = TotalSalesDay
                MaxSalesDay = "Day " & (i + 1).ToString()

            End If

        Next

        'Output
        ListBox1.Items.Add("The most sales from both stores was on " & MaxSalesDay & " - Amount of : " & "$" & MaxSales.ToString("N2"))

    End Sub

    Sub AverageSales()

        'Declaring variables

        Dim First, Midle, Last, FirstAverage, SecondAverage, LastAverage As Double

        'Looping through first ten days, second ten days, and third 10 days and calculating the average

        For i As Integer = 0 To 9
            First += NormalSales(i)
        Next

        FirstAverage = First / 10

        For i As Integer = 10 To 19

            Midle += NormalSales(i)
        Next

        SecondAverage = Midle / 10

        For i As Integer = 20 To 29

            last += NormalSales(i)
        Next

        LastAverage = Last / 10

        'output

        ListBox1.Items.Add("") ' Add empty line
        ListBox1.Items.Add("Average Sales from Normal Store:")
        ListBox1.Items.Add("Day 1-10:" & " " & "$" & FirstAverage.ToString("N2"))
        ListBox1.Items.Add("Day 11-20:" & " " & "$" & SecondAverage.ToString("N2"))
        ListBox1.Items.Add("Day 21-0:" & " " & "$" & LastAverage.ToString("N2"))

    End Sub

    Sub BloomingtonLeastSales()

        'Declaring variabes

        Dim LeastSalesDay, AmountOfLeastSales As Double

        'Looping through the array to find the min

        For i As Integer = 0 To BloomingtonSales.Count - 1

            'Calculating 

            LeastSalesDay = BloomingtonSales.Min

            If CDbl(BloomingtonSales(i)) = LeastSalesDay Then
                LeastSalesDay = i + 1 ' add 1 to get the day number
                AmountOfLeastSales = BloomingtonSales.Min

                ' Exit loop once we find the first occurrence of the minimum sales value

                Exit For

            End If

        Next

        'I found Another way to get the day and amount without having to loop through the array. To use it, uncomment the code below and comment out the code (loop) above

        'LeastSalesDay = BloomingtonSales.Min
        'LeastSalesDay = Array.IndexOf(BloomingtonSales, BloomingtonSales.Min()) + 1 ' add 1 to get the day number
        'AmountOfLeastSales = BloomingtonSales.Min



        'Output

        ListBox1.Items.Add("") ' Add empty line
        ListBox1.Items.Add("Bloomington Store sold the least on Day " & LeastSalesDay & " - Amount of : " & "$" & AmountOfLeastSales.ToString("N2"))

    End Sub


End Class
