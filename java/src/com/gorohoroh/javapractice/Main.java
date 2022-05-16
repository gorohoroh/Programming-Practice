package com.gorohoroh.javapractice;

import java.text.MessageFormat;

public class Main {

    public static void main(String[] args) {
        primitiveNumericTypeLimitations();
    }

    private static void primitiveNumericTypeLimitations() {
        short[] numbers = { -40, 0, 1, 52, 99, 127, 129, 255, 512, 1024, 3999};

        for (int number : numbers) {
            byte numberAsByte = (byte) number;
            System.out.println(MessageFormat.format("Original value in 16-bit Short: {0}. Byte value after conversion: {1} (bit sequence: {2}).", number, numberAsByte, byteToBinaryString(numberAsByte)));

            if (number < -127 || number > 127) {
                System.out.println("Casting to a Byte of a number that is outside the range of {-127, 127} results in an incorrect conversion because trailing bits that do not fit get trimmed.");
            }
        }
    }

    private static String byteToBinaryString(byte numberAsByte) {
        return String.format("%8s", Integer.toBinaryString(numberAsByte & 0xff)).replace(' ', '0');
    }
}
