/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package testQueue;

import PriorityQueue.DoublyLinkedList;
import PriorityQueue.PriorityQueue;

/**
 *
 * @author triet
 */
public class Program {
    public static void main(String[] args) {
        Menu mainMenu = new Menu("_____________\nPriority Queue - Main menu:");
        mainMenu.add("Input an Integer Priority queue");
        mainMenu.add("Input a String Priority queue");
        mainMenu.add("Queue function:");
        
        DoublyLinkedList currentList = new DoublyLinkedList();
        PriorityQueue currentQueue = new PriorityQueue();
        int mainChoice;
        
        Menu subMenu = new Menu("_____________\n");
        subMenu.add("Enqueue");
        subMenu.add("Dequeue");
        subMenu.add("Front");
        subMenu.add("Clear");
        subMenu.add("Check if the queue is empty?");
        subMenu.add("Print all");
        
        int subChoice;
        do{
            mainChoice = mainMenu.getUserChoice();
            switch(mainChoice){
                case 1:
                    currentList = MyScanner.getLineNumber("Input a list of Integer divided by a space character: ");
                    currentQueue = new PriorityQueue<Integer>(currentList);
                    currentQueue.printAll();
                    break;
                    
                case 2:
                    currentList = MyScanner.getLineWord("Input a list of word divided by a space character: ");
                    currentQueue = new PriorityQueue<Integer>(currentList);
                    currentQueue.printAll();
                    break;
                    
                case 3:
                    do{
                        subChoice = subMenu.getUserChoice();
                        switch(subChoice){
                            case 1:
                                Integer newest1;
                                String newest2;
                                if(currentQueue.isEmpty()){
                                    boolean choice = MyScanner.getBoolean("Empty queue! What do you want to store in the queue? (T/1/Y for INTEGER,F/0/N for WORD)");
                                    if(choice) {
                                        currentQueue = new PriorityQueue<Integer>();
                                        newest1 = MyScanner.getInt("Input an Integer to enqeue: ");
                                         currentQueue.enqueue(newest1);
                                    }
                                        
                                    else {
                                        currentQueue = new PriorityQueue<String>();
                                        
                                        newest2 = MyScanner.getNonBlankStr("Input a word to enqeue: ");
                                         currentQueue.enqueue(newest2);
                                    }
                                }else{
                                    if(currentQueue.front() instanceof Integer)  {
                                        newest1 = MyScanner.getInt("Input an Integer to enqeue: ");
                                        currentQueue.enqueue(newest1);
                                    } 
                                    else {
                                        newest2 =  MyScanner.getNonBlankStr("Input a word to enqeue: ");
                                        currentQueue.enqueue(newest2);
                                    }
                                }
                               
                                System.out.println("Done!");
                                break;

                            case 2:
                               Object highest= currentQueue.dequeue();
                                if(highest!=null) System.out.println("Take "+highest.toString()+" from the priority queue!");
                                else System.out.println("Empty queue!");
                                break;
                                
                            case 3:
                                Object highest2 = currentQueue.front();
                                if(highest2!=null) System.out.println("The highest priority element in priority queue is: "+highest2.toString());
                                 else System.out.println("Empty queue!");
                                break;
                            case 4:
                                currentQueue.clear();
                                System.out.println("Done!");
                                break;
                             case 5:
                                if(currentQueue.isEmpty()) System.out.println("Yes! The queue is empty!");
                                else System.out.println("No! The queue is not empty!");
                                break;   
                            case 6:
                                currentQueue.printAll();
                                break;
                            default:
                                System.out.println("Back to main menu!!!");

                        }
                    
                    }while (subChoice > 0 && subChoice <=subMenu.size()); 
                    break;
                default:
                    System.out.println("Thank you.");
        
    }
        }while (mainChoice > 0 && mainChoice <=mainMenu.size()); 
    }
}
