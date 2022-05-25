package com.gorohoroh.javapractice;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class WorkingWithFiles {

    public static void javaNio() {
//        readTextFile();
        writeToTextFile();
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