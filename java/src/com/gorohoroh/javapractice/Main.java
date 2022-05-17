package com.gorohoroh.javapractice;

import java.text.MessageFormat;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
//        primitiveNumericTypeLimitations();
        stringFormatting();
    }

    private static void stringFormatting() {

        List<Player> playersOverThousandWins = Arrays.asList(
                new Player("Roger Federer", 40, 2015),
                new Player("Novak Djokovic", 34, 2022),
                new Player("Rafael Nadal", 35, 2020));
        Player federer = playersOverThousandWins.get(0);

        String stringFormat = String.format("There are %d active tennis players who have won at least 1000 matches in their careers. One of them is %s (age %d) who has won their 1000th match in %d.", playersOverThousandWins.size(), federer.name, federer.age, federer.yearThousandMatchesWon);

        String messageFormat = MessageFormat.format("There are {0} active tennis players who have won at least 1000 matches in their careers. One of them is {1} (age {2}) who has won their 1000th match in {3}.", playersOverThousandWins.size(), federer.name, federer.age, String.format("%d", federer.yearThousandMatchesWon));

        String averageAgeWithStringFormatAndStream = String.format("The average age of the three players is %.1f years", playersOverThousandWins.stream().mapToDouble(value -> value.age).average().orElse(Double.NaN));

        String currentTimeInMilliseconds = String.format("%,d", System.currentTimeMillis());

        System.out.println(stringFormat);
        System.out.println(averageAgeWithStringFormatAndStream);
        System.out.println(currentTimeInMilliseconds);
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
