﻿using Sorting.basic_class.@static;
using Sorting.basic_class.dynamic;
using Sorting.enums;
using Sorting.manager;
using Sorting.print;
using Sorting.reader;
using Sorting.sorting.simple;
using Sorting.utils;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Selecione o arquivo desejado:");
        Console.WriteLine("1 - 10-aleatorios.txt");
        Console.WriteLine("2 - 100-aleatorios.txt");
        Console.WriteLine("3 - 1000-aleatorios.txt");
        Console.WriteLine("4 - 10000-aleatorios.txt");
        Console.WriteLine("5 - 100000-aleatorios.txt");
        Console.WriteLine("6 - 1000000-aleatorios.txt");
        Console.WriteLine("7 - 1000000-ordenados.txt");

        string[] arquivos =
        {
            "inputs/10-aleatorios.txt",
            "inputs/100-aleatorios.txt",
            "inputs/1000-aleatorios.txt",
            "inputs/10000-aleatorios.txt",
            "inputs/100000-aleatorios.txt",
            "inputs/1000000-aleatorios.txt",
            "inputs/1000000-ordenados.txt"
        };

        int escolhaArquivo = int.Parse(Console.ReadLine() ?? "1");
        if (escolhaArquivo < 1 || escolhaArquivo > arquivos.Length)
        {
            Console.WriteLine("Arquivo inválido.");
            return;
        }

        var caminho = arquivos[escolhaArquivo - 1];
        int[] array = ReaderFile.LerArquivo(caminho);

        Console.WriteLine("Escolha o algoritmo de ordenação:");
        Console.WriteLine("1 - BubbleSort");
        Console.WriteLine("2 - InsertionSort");
        Console.WriteLine("3 - SelectionSort");
        Console.WriteLine("4 - QuickSort");
        Console.WriteLine("5 - MergeSort");
        Console.WriteLine("6 - HeapSort");
        Console.WriteLine("7 - ShellSort");
        Console.WriteLine("8 - CountingSort");
        Console.WriteLine("9 - RadixSort");
        Console.WriteLine("10 - BucketSort");

        int escolhaAlg = int.Parse(Console.ReadLine() ?? "1");
        if (!Enum.IsDefined(typeof(Sortings), escolhaAlg - 1))
        {
            Console.WriteLine("Algoritmo inválido.");
            return;
        }
        var algoritmo = (Sortings)(escolhaAlg - 1);

        if (array.Length <= 100)
        {
            Console.WriteLine("Vetor original:");
            PrintSolutionStatic.ImprimirArrayMesmaLinha(array, algoritmo);
        }

        UtilCountingTime.StartCount();
        ManagerFileSorting.Ordenar(algoritmo, array);
        UtilCountingTime.EndCount();

        if (array.Length <= 100)
        {
            Console.WriteLine("Vetor ordenado:");
            PrintSolutionStatic.ImprimirArrayMesmaLinha(array, algoritmo);
        }
        UtilCountingTime.PrintCount();

        //  Questão 7 – FILA E PILHA ESTÁTICA
        Console.WriteLine("\n--- Q7: Fila e Pilha Estática (100 elementos) ---");
        int[] pequenos = ReaderFile.LerArquivo("inputs/100-aleatorios.txt");

        var filaEst = new Fila(pequenos.Length);
        foreach (var x in pequenos) filaEst.Inserir(x);
        filaEst.Remover(); filaEst.Remover(); filaEst.Remover();
        Console.Write("Fila estática: ");
        filaEst.Mostrar();

        var pilhaEst = new Pilha(pequenos.Length);
        foreach (var x in pequenos) pilhaEst.Inserir(x);
        pilhaEst.Remover(); pilhaEst.Remover(); pilhaEst.Remover();
        Console.WriteLine("Pilha estática:");
        pilhaEst.Mostrar();

        // Questão 9 – LISTA ESTÁTICA + ORDENAÇÃO
        Console.WriteLine("\n--- Q9: Lista Estática + BubbleSort (1.000.000 elementos) ---");
        int[] milhao = ReaderFile.LerArquivo("inputs/1000000-aleatorios.txt");
        var listaEst = new Lista(milhao.Length);
        foreach (var x in milhao) listaEst.InserirFim(x);

        var cloneEst = UtilClonar.Clonar(listaEst.lista);
        UtilCountingTime.StartCount();
        BubbleSort.Sorting(cloneEst);
        UtilCountingTime.EndCount();
        Console.WriteLine("BubbleSort em lista estática:");
        UtilCountingTime.PrintCount();

        // Questão 10 – ESTRUTURAS DINÂMICAS
        Console.WriteLine("\n--- Q10: Fila Dinâmica ---");
        var filaDin = new FilaDynamic();
        filaDin.Inserir(10);
        filaDin.Inserir(20);
        filaDin.Inserir(30);
        filaDin.Mostrar();
        filaDin.Remover();
        filaDin.Mostrar();

        Console.WriteLine("\n--- Q10: Pilha Dinâmica (usando Pilha estática como base) ---");

        var pilhaDin = new Pilha(10);
        pilhaDin.Inserir(100);
        pilhaDin.Inserir(200);
        pilhaDin.Inserir(300);
        Console.WriteLine("Pilha dinâmica simulada (inserções):");
        pilhaDin.Mostrar();
        pilhaDin.Remover();
        pilhaDin.Remover();
        Console.WriteLine("Pilha dinâmica simulada (remoções):");
        pilhaDin.Mostrar();

        Console.WriteLine("\n--- Q10: Lista Dinâmica (Duplamente Encadeada) ---");
        var listaDin = new ListaDuplamenteEncadeada();
        listaDin.Inserir(7);
        listaDin.Inserir(2);
        listaDin.Inserir(9);
        Console.Write("Antes: ");
        listaDin.Mostrar();
        listaDin.BubbleSort();
        Console.Write("Depois: ");
        listaDin.Mostrar();

    }
}