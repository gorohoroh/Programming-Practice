package com.gorohoroh.javapractice;

import java.text.MessageFormat;
import java.time.*;
import java.time.format.DateTimeFormatter;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
//        primitiveNumericTypeLimitations();
//        stringFormatting();
//        basicTimeTypes();
        WorkingWithFiles.javaNio();
    }

    private static void basicTimeTypes() {

        Instant instant = Instant.now();
        LocalDate localDate = LocalDate.now();
        LocalTime localTime = LocalTime.now();
        LocalDateTime localDateTime = LocalDateTime.now();
        ZonedDateTime zonedDateTime = ZonedDateTime.now();

        DateTimeFormatter usFormatter = DateTimeFormatter.ofPattern("MM-dd-yyyy");
        String usDateString = "07-04-2022";
//        LocalDate failedParse = LocalDate.parse(usDateString); // This would cause a DateTimeParseException
        LocalDate correctlyParsedDate = LocalDate.parse(usDateString, usFormatter);

        System.out.printf("What's the current UTC date and time? %s%n", instant);
        System.out.printf("What's the local date today? %s%n", localDate);
        System.out.printf("What's the local time right now? %s%n", localTime);
        System.out.printf("What's the local date and time right now? %s%n", localDateTime);
        System.out.printf("Today is %s %s, %s and the local time is %s:%s in %s.%n", zonedDateTime.getMonth(), zonedDateTime.getDayOfMonth(), zonedDateTime.getYear(), zonedDateTime.getHour(), zonedDateTime.getMinute(), zonedDateTime.getZone());
        System.out.printf("Americans would expect to read today's date as follows: %s.%n", localDate.format(usFormatter));
        System.out.printf("Here's a date parsed from a string using a US-style date formatter: %s.%n", correctlyParsedDate);

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
