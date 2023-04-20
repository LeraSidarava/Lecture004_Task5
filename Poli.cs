using System;

public class Polynomial
{
    private double[] coefficients;
    public Polynomial(params double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    // Property to get the degree of the polynomial
    public int PolyLength
    {
        get { return coefficients.Length - 1; }
    }

    // Indexer to get or set the coefficient at a specific index
    public double this[int index]
    {
        get { return coefficients[index]; }
        set { coefficients[index] = value; }
    }

    // Method to convert the polynomial to a string
    public override string ToString()
    {
        string result = "";
        for (int i = PolyLength; i >= 0; i--)
        {
            if (coefficients[i] == 0)
            {
                continue;
            }
            else if (i == PolyLength)
            {
                result += coefficients[i];
            }
            else if (coefficients[i] < 0)
            {
                result += " - " + Math.Abs(coefficients[i]);
            }
            else
            {
                result += " + " + coefficients[i];
            }

            if (i == 1)
            {
                result += "x";
            }
            else if (i > 1)
            {
                result += "x^" + i;
            }
        }

        return result;
    }

    // Overloaded operator to add two polynomials
    public static Polynomial operator +(Polynomial p1, Polynomial p2)
    {
        int length = Math.Max(p1.PolyLength, p2.PolyLength) + 1;
        double[] coefficients = new double[length];

        for (int i = 0; i < length; i++)
        {
            double value1 = i <= p1.PolyLength ? p1[i] : 0;
            double value2 = i <= p2.PolyLength ? p2[i] : 0;
            coefficients[i] = value1 + value2;
        }

        return new Polynomial(coefficients);
    }

    // Overloaded operator to subtract two polynomials
    public static Polynomial operator -(Polynomial p1, Polynomial p2)
    {
        int length = Math.Max(p1.PolyLength, p2.PolyLength) + 1;
        double[] coefficients = new double[length];

        for (int i = 0; i < length; i++)
        {
            double value1 = i <= p1.PolyLength ? p1[i] : 0;
            double value2 = i <= p2.PolyLength ? p2[i] : 0;
            coefficients[i] = value1 - value2;
        }

        return new Polynomial(coefficients);
    }

    // Overloaded operator to multiply two polynomials
    public static Polynomial operator *(Polynomial p1, Polynomial p2)
    {
        int length = p1.PolyLength + p2.PolyLength + 1;
        double[] coefficients = new double[length];

        for (int i = 0; i <= p1.PolyLength; i++)
        {
            for (int j = 0; j <= p2.PolyLength; j++)
            {
                coefficients[i + j] += p1[i] * p2[j];
            }
        }

        return new Polynomial(coefficients);
    }
}
