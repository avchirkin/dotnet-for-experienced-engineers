﻿string[] strings = ["Hello", "Group", "!"];

object[] objects = strings; // Ковариантное присваивание - массив элементов дочернего типа сохраняется как массив элементов родительского типа

objects[0] = "Greetings"; // Ок
objects[1] = 42; // ВОПРОС - что произойдёт в рантайме?