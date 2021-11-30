/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package testQueue;

import PriorityQueue.DoublyLinkedList;
import static java.lang.Integer.MAX_VALUE;
import static java.lang.Integer.MIN_VALUE;
import java.util.Scanner;
import java.util.StringTokenizer;

/**
 *
 * @author triet
 */
public class MyScanner {
    public static boolean getBoolean(String message)
    {
        boolean result = false;
        boolean nhaplai=false;
        do{
            System.out.print(message + "(T/F, Y/N, 1/0): ");
            try{
                Scanner sc = new Scanner(System.in);
                String tmp = sc.nextLine().trim();
                if(tmp.equalsIgnoreCase("T") || tmp.equalsIgnoreCase("Y") || tmp.equalsIgnoreCase("1")) result = true;
                else 
                    if(tmp.equalsIgnoreCase("N") || tmp.equalsIgnoreCase("F") || tmp.equalsIgnoreCase("0")) result= false;
                        else throw new Exception();
                nhaplai=false;
            }catch(Exception e){
                System.out.println("Invalid input! Try again!");
                nhaplai=true;
            }
        }while(nhaplai);
        return result;
    }
    
    
    public static int getInt(String message, int min, int max)
    {
        int number = 0;
        boolean nhaplai = false;
        do{
            try {
                Scanner sc = new Scanner(System.in);
                System.out.print(message + "(" + min + ".." + max + "): ");
                number = sc.nextInt();
                if(number<min || number>max) throw new Exception();
                nhaplai=false;
            } catch (Exception e) {
                System.out.println("Invalid input! Try again!");
                nhaplai=true;
            }
        }
        while (nhaplai);
        return number;
    }
    
    public static int getInt(String message, int max)
    {
        return getInt(message,0, max);
    }
    
    public static Integer getInt(String msg){
        return getInt(msg, MIN_VALUE, MAX_VALUE);
    }
    
    public static DoublyLinkedList<Integer>  getLineNumber(String message)
    {
        String line = "";
        DoublyLinkedList<Integer> result = new DoublyLinkedList<>();
        boolean nhaplai = false;
        do{
            try{
                result.clear();
                Scanner sc = new Scanner(System.in);
                System.out.print(message);
                line = sc.nextLine();
                StringTokenizer stk = new StringTokenizer(line," ");
                while (stk.hasMoreTokens()){
                    result.AddFirst(Integer.parseInt(stk.nextToken()));
                }
                nhaplai=false;
            }catch(Exception e){
                System.out.println("Invalid input! Try again!");
                nhaplai=true;
            }
        }while (nhaplai);
        
        return result;
    }
    
    public static DoublyLinkedList<String>  getLineWord(String message)
    {
        String line = "";
        DoublyLinkedList<String> result = new DoublyLinkedList<>();
        boolean nhaplai = false;
        do{
            try{
                result.clear();
                Scanner sc = new Scanner(System.in);
                System.out.print(message);
                line = sc.nextLine();
                StringTokenizer stk = new StringTokenizer(line," ");
                while (stk.hasMoreTokens()){
                    result.AddFirst(stk.nextToken());
                }
                nhaplai=false;
            }catch(Exception e){
                System.out.println("Invalid input! Try again!");
                nhaplai=true;
            }
        }while (nhaplai);
        
        return result;
    }
    
    public static String getNonBlankStr(String message)
    {
        String result = "";
        boolean nhaplai = false;
        do{
            try{
                Scanner sc = new Scanner(System.in);
                System.out.print(message);
                result = sc.nextLine();
                if(result.isEmpty())
                    throw new Exception();
                nhaplai=false;
            }catch(Exception e){
                System.out.println("Invalid input! Try again!");
                nhaplai=true;
            }
        }while (result.isEmpty());
        
        return result;
    }
}
