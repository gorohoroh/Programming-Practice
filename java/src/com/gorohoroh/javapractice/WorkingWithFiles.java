package com.gorohoroh.javapractice;

import java.io.BufferedReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class WorkingWithFiles {

    public static void javaNio() {
        readTextFile();
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