#include <stdio.h>
#include <stdlib.h>

double getDX();
double integrate(double coeff, int exponent, double end);

int main()
{
    //Coefficient, x raised to some exponent, upper limit (from 0)
    double total = integrate(2.0f, 5, 20.0f);

    printf("%.2f", total);
    return 0;
}

double integrate(double coeff, int exponent, double end){

    double total = 0.0f;
    double dx = .000001; //getDX();

    double x = 0;
    double tempX = 0;

    int i = 0;

    for(x = 0; x < end; x += dx){

        tempX = x;

        if(exponent == 0) tempX = 1;

        for(i = 1; i < exponent; i++)
            tempX *= x;

        total += coeff * tempX * dx;
    }

    return total;
}

double getDX(){


    double DX = .05f;
    int i = 0;
    for(i = 0; i < 20; i++){

        DX = DX/2.0f;
    }

    return DX;
}


