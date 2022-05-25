package com.gorohoroh.javapractice;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;
import java.util.stream.Stream;

public class WorkingWithFiles {

    public static void javaNio() {
//        readTextFile();
//        writeToTextFile();
//        readFromCsvFileDeclaratively();
        readFromCsvFileUsingStream();
    }

    private static void readFromCsvFileDeclaratively() {
        Path path = Path.of("files/data.csv");
        Function<String, Person> lineToPerson = line -> lineToPerson(line);

        try (BufferedReader reader = Files.newBufferedReader(path)) {
            String line = reader.readLine();
            while (line != null) {
                if (!line.startsWith("#")) {
                    Person person = lineToPerson.apply(line);
                    System.out.println("Person: " + person);
                }
                line = reader.readLine();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void readFromCsvFileUsingStream() {
        Path path = Path.of("files/data.csv");
        Function<String, Person> lineToPerson = line -> lineToPerson(line);

        try (Stream<String> lines = Files.lines(path)) {
            lines
                .filter(line -> !line.startsWith("#"))
                .map(lineToPerson)
                .forEach(System.out::println);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static Person lineToPerson(String line) {
        String[] elements = line.split(";");

        String name = elements[0];
        int age = Integer.parseInt(elements[1]);
        String city = elements[2];

        return new Person(name, age, city);

    }

    private static void writeToTextFile() {
        Path path = Paths.get("files/writeHere.txt");
        try (BufferedWriter writer = Files.newBufferedWriter(path)) {
            if(!Files.exists(path)) Files.createFile(path);
            writer.write("The first line to write");
            writer.write(System.lineSeparator());
            writer.write("The second line to write");

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void readTextFile() {
        Path path = Paths.get("files/lyrics.txt");
        try (BufferedReader reader = Files.newBufferedReader(path)) {
            if (!Files.exists(path)) Files.createFile(path);
            String line;
            while ((line = reader.readLine()) != null) {
                System.out.println(line);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}