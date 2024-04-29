using System;
using System.IO;
using System.Text;

class Program
{   
    static char[,] criarTabuleiroMaquina()
    {
        char[,] tabuleiroMaquina = new char[10, 10];

        for (int i = 0; i < tabuleiroMaquina.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiroMaquina.GetLength(1); j++)
            {
                tabuleiroMaquina[i, j] = ' ';
            }
        }
        return tabuleiroMaquina;
    }

    static void inserirEmbarcacao(char[,] tabuleiroMaquina, int[] tamEmbarcacao, char nomeEmbarcacao, int indiceEmbarcacao, out int indiceLinha, out int indiceColuna, out char posicao)
    {
        indiceLinha = 0;
        indiceColuna = 0;
        Random posicaoRandomlinha = new Random();
        Random posicaoRandomcoluna = new Random();
        Random r = new Random();

        int linOucol = r.Next(0, 2);
        posicao = ' ';
        if (linOucol == 0)
            posicao = 'h';
        else if (linOucol == 1)
            posicao = 'v';

        bool posicaoInvalida = true;
        while (posicaoInvalida)
        {
            indiceLinha = posicaoRandomlinha.Next(0, 10);
            indiceColuna = posicaoRandomcoluna.Next(0, 10);

            if (linOucol == 0)
            {
                if (indiceColuna + tamEmbarcacao[indiceEmbarcacao] <= 10)
                {
                    for (int col = indiceColuna; col < indiceColuna + tamEmbarcacao[indiceEmbarcacao]; col++)
                    {
                        if (tabuleiroMaquina[indiceLinha, col] != ' ')
                        {
                            posicaoInvalida = true;
                            col = indiceColuna + tamEmbarcacao[indiceEmbarcacao];
                        }
                        else
                            posicaoInvalida = false;
                    }
                }
                else
                    posicaoInvalida = true;
            }
            else if (linOucol == 1)
            {
                if (indiceLinha + tamEmbarcacao[indiceEmbarcacao] <= 10)
                {
                    for (int lin = indiceLinha; lin < indiceLinha + tamEmbarcacao[indiceEmbarcacao]; lin++)
                    {
                        if (tabuleiroMaquina[lin, indiceColuna] != ' ')
                        {
                            posicaoInvalida = true;
                            lin = indiceLinha + tamEmbarcacao[indiceEmbarcacao];
                        }
                        else
                            posicaoInvalida = false;
                    }
                }
                else
                    posicaoInvalida = true;
            }
        }
        if (!posicaoInvalida && linOucol == 0)
        {
            for (int col = indiceColuna; col < indiceColuna + tamEmbarcacao[indiceEmbarcacao]; col++)
                tabuleiroMaquina[indiceLinha, col] = nomeEmbarcacao;

        }
        else if (!posicaoInvalida && linOucol == 1)
        {
            for (int lin = indiceLinha; lin < indiceLinha + tamEmbarcacao[indiceEmbarcacao]; lin++)
                tabuleiroMaquina[lin, indiceColuna] = nomeEmbarcacao;
        }
    }

    static void gerarArquivoMaquina(char[,] tabuleiroMaquina)
    {
        int[] tamEmbarcacao = { 1, 2, 3, 4, 5 };
        char[] inicialEmbarcs = { 'S', 'H', 'C', 'E', 'P' };
        string[] nomeEmbarcs = { "Submarino", "Hidroavião", "Cruzador", "Encouraçado", "Porta-aviões" };
        int quantSubmarinos = 4, quantHidroaviao = 3, quantCruzador = 2;
        int indiceLinha, indiceColuna; char posicao;
        string[] gerarArqMaquina = new string[12];
        int j = 0;

        for (int i = 0; i < quantSubmarinos; i++)
        {
            j++;
            inserirEmbarcacao(tabuleiroMaquina, tamEmbarcacao, inicialEmbarcs[0], 0, out indiceLinha, out indiceColuna, out posicao);
            gerarArqMaquina[j] = nomeEmbarcs[0] + ";" + posicao + ";" + indiceLinha + ";" + indiceColuna;
        }
        for (int i = 0; i < quantHidroaviao; i++)
        {
            j++;
            inserirEmbarcacao(tabuleiroMaquina, tamEmbarcacao, inicialEmbarcs[1], 1, out indiceLinha, out indiceColuna, out posicao);
            gerarArqMaquina[j] = nomeEmbarcs[1] + ";" + posicao + ";" + indiceLinha + ";" + indiceColuna;
        }
        for (int i = 0; i < quantCruzador; i++)
        {
            j++;
            inserirEmbarcacao(tabuleiroMaquina, tamEmbarcacao, inicialEmbarcs[2], 2, out indiceLinha, out indiceColuna, out posicao);
            gerarArqMaquina[j] = nomeEmbarcs[2] + ";" + posicao + ";" + indiceLinha + ";" + indiceColuna;
        }
        j++;
        inserirEmbarcacao(tabuleiroMaquina, tamEmbarcacao, inicialEmbarcs[3], 3, out indiceLinha, out indiceColuna, out posicao);
        gerarArqMaquina[j] = nomeEmbarcs[3] + ";" + posicao + ";" + indiceLinha + ";" + indiceColuna;

        j++;
        inserirEmbarcacao(tabuleiroMaquina, tamEmbarcacao, inicialEmbarcs[4], 4, out indiceLinha, out indiceColuna, out posicao);
        gerarArqMaquina[j] = nomeEmbarcs[4] + ";" + posicao + ";" + indiceLinha + ";" + indiceColuna;
        salvarArquivoMaquina(gerarArqMaquina);
    }

    static void salvarArquivoMaquina(string[] gerarArqMaquina)
    {
        StreamWriter arq = new StreamWriter("/Users/jonathanfaulkner/Desktop/Trabalho-ATP/frotaComputador.txt", false, Encoding.UTF8);

        for (int i = 1; i < gerarArqMaquina.Length; i++)
            arq.WriteLine(gerarArqMaquina[i]);

        arq.Close();
    }

    static string criarNickname()
    {
        Console.Write("Informe o seu nome completo -->: ");
        string nomeFull = Console.ReadLine();

        string[] nomes = nomeFull.Split(" ");
        string primeiroNome = nomes.Length > 0 ? nomes[0] : "";
        string iniciais = "";

        for (int i = 1; i < nomes.Length; i++)
        {
            iniciais += i < nomes.Length && nomes[i].Length > 0 ? nomes[i][0].ToString() : "";
        }

        string nickname = primeiroNome + iniciais;

        Console.Write("\nSeu Nickname é --> :");
        Console.WriteLine($"[=== {nickname.ToUpper()} ===]\n");

        return nickname;
    }

    static char[,] criarMatrizJogador()
    {
        char[,] tabuleirojogador = new char[10, 10];

        for (int i = 0; i < tabuleirojogador.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleirojogador.GetLength(1); j++)
            {
                tabuleirojogador[i, j] = ' ';
            }
        }
        return tabuleirojogador;
    }

    static bool inserirEmbarcUSer(char[,] tabuleirojogador, int[] tamEmbarcacao, char nomeEmbarcacao, int indiceLinha, int indiceColuna, int linOucol, int indiceEmbarcacao)
    {
        bool posicaoInvalida = true;
        while (posicaoInvalida)
        {
            if (linOucol == 0)
            {
                if (indiceColuna + tamEmbarcacao[indiceEmbarcacao] <= 10)
                {
                    for (int col = indiceColuna; col < indiceColuna + tamEmbarcacao[indiceEmbarcacao]; col++)
                    {
                        if (tabuleirojogador[indiceLinha, col] != ' ')
                            return true;

                        else
                            posicaoInvalida = false;
                    }
                }
                else
                    return true;
            }
            else if (linOucol == 1)
            {
                if (indiceLinha + tamEmbarcacao[indiceEmbarcacao] <= 10)
                {
                    for (int lin = indiceLinha; lin < indiceLinha + tamEmbarcacao[indiceEmbarcacao]; lin++)
                    {
                        if (tabuleirojogador[lin, indiceColuna] != ' ')
                            return true;

                        else
                            posicaoInvalida = false;
                    }
                }
                else
                    return true;
            }
        }
        if (!posicaoInvalida && linOucol == 0)
        {
            for (int col = indiceColuna; col < indiceColuna + tamEmbarcacao[indiceEmbarcacao]; col++)
                tabuleirojogador[indiceLinha, col] = nomeEmbarcacao;

            return false;
        }
        else if (!posicaoInvalida && linOucol == 1)
        {
            for (int lin = indiceLinha; lin < indiceLinha + tamEmbarcacao[indiceEmbarcacao]; lin++)
                tabuleirojogador[lin, indiceColuna] = nomeEmbarcacao;

            return false;
        }
        return true;
    }

    static void posicionarEmbarcUSER(char[,] tabuleirojogador, string nickname)
    {
        int[] QuantEmbarcacao = { 4, 3, 2, 1, 1 };
        int[] tamEmbarcacao = { 1, 2, 3, 4, 5 };
        char[] inicialEmbarcs = { 'S', 'H', 'C', 'E', 'P' };
        string[] nomeEmbarcs = { "Submarino", "Hidroavião", "Cruzador", "Encouraçado", "Porta-aviões" };
        int indiceLinha = 0;
        int indiceColuna = 0;
        string letra = "";
        int linOUcol = 0;
        char nomeEmbarcacao = ' ';
        bool existirEmbarc = true;
        int indiceEmbarc = 0;
        int segundavez = 1;

        while (existirEmbarc)
        {
            if (segundavez != 1)
                exibeEmbarcUserInterna(tabuleirojogador);

            segundavez++;
            Console.WriteLine($"\n\t\t                               [=== EMBARCAÇÕES E QUANTIDADES ===]\n");
            Console.WriteLine();
            Console.WriteLine($"╭──────────────────────────╭───────────────────────────╭─────────────────────────╭────────────────────────────╭─────────────────────────────╮");
            Console.WriteLine($"│ Submarino = S │ Quant: {QuantEmbarcacao[0]} │ Hidroavião = H | Quant: {QuantEmbarcacao[1]} | Cruzador = C | Quant: {QuantEmbarcacao[2]} | Encouraçado = E | Quant: {QuantEmbarcacao[3]} | Porta-aviões = P | Quant: {QuantEmbarcacao[4]} |");
            Console.WriteLine($"╰───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╯");

            bool naoPossuirEmbarc = true;
            while (naoPossuirEmbarc)
            {

                indiceEmbarc = 0;
                bool inicialInvalida = true;
                while (inicialInvalida)
                {
                    Console.WriteLine($"\n           [=== {nickname.ToUpper()} ===]\n");
                    Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * \n");
                    Console.WriteLine($"Digite a inicial da embarcação a ser escolhida");
                    Console.Write($"qual será embarcação a ser escolhida ? -> ");
                    letra = Console.ReadLine();
                    letra = letra.ToUpper();
                    nomeEmbarcacao = letra[0];
                    Console.WriteLine();

                    for (int i = 0; i < inicialEmbarcs.Length; i++)
                    {
                        if (letra[0] == inicialEmbarcs[i])
                        {
                            inicialInvalida = false;
                            indiceEmbarc = i;
                            i = inicialEmbarcs.Length;
                        }
                        else
                            inicialInvalida = true;
                    }
                    if (inicialInvalida)
                    {
                        Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║  ⚠ !!! Aviso: Não existem Embarcações com essa inicial. Favor informar uma inicial válida. !!! ⚠ ║");
                        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════════╝");
                    }

                }

                if (QuantEmbarcacao[indiceEmbarc] != 0)
                    naoPossuirEmbarc = false;
                else
                {
                    Console.WriteLine("\n╔═══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine($"║  ⚠ !!! Aviso: você não tem mais {nomeEmbarcs[indiceEmbarc]} para inserir\n Escolha outra embarcação !!! ⚠ ║");
                    Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                    naoPossuirEmbarc = true;
                }
            }
            bool jogadaInvalida = true;
            int indiceParaDecrementar = 0;
            while (jogadaInvalida)
            {
                exibeEmbarcUserInterna(tabuleirojogador);

                string quantIniciais = " ";
                for (int j = 0; j < tamEmbarcacao[indiceEmbarc]; j++)
                    quantIniciais += inicialEmbarcs[indiceEmbarc].ToString();

                Console.WriteLine($"╭──────────────────────────────────────────────────────────╮");
                Console.WriteLine($"    {nomeEmbarcs[indiceEmbarc],-15} Quant: {QuantEmbarcacao[indiceEmbarc],-5} No tabuleiro --> {quantIniciais,-5} ");
                Console.WriteLine($"╰──────────────────────────────────────────────────────────╯");
                bool tamanhoInvalido = true;
                while (tamanhoInvalido)
                {
                    Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * \n");
                    Console.WriteLine($"Informe a jogada");
                    Console.Write($"Valor da linha é -> : ");
                    indiceLinha = int.Parse(Console.ReadLine());
                    Console.Write($"Valor da coluna é -> : ");
                    indiceColuna = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    bool tamIvalidoLinha = indiceLinha >= 0 && indiceLinha <= 9;
                    bool tamIvalidoCol = indiceColuna >= 0 && indiceColuna <= 9;

                    if (tamIvalidoLinha && tamIvalidoCol)
                        tamanhoInvalido = false;

                    else
                    {
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("   ⚠ !!! Aviso: Os valores informados estão fora dos limites de 0 a 9, Insira outros valores !!! ⚠ ");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝");
                    }
                    if (letra != "S")
                    {
                        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * \n");
                        Console.Write($"ESCOLHA A DIREÇÃO:\nDigite (h) para Horizontal ou (v) para Vertical --> ");
                        char direção = char.Parse(Console.ReadLine());
                        direção = char.ToUpper(direção);

                        if (direção == 'H')
                            linOUcol = 0;
                        else
                            linOUcol = 1;
                    }
                    int indiceEmbarcacao = 0;
                    for (int i = 0; i < inicialEmbarcs.Length; i++)
                    {
                        if (nomeEmbarcacao == inicialEmbarcs[i])
                        {
                            indiceParaDecrementar = i;
                            indiceEmbarcacao = i;
                        }
                    }
                    jogadaInvalida = inserirEmbarcUSer(tabuleirojogador, tamEmbarcacao, nomeEmbarcacao, indiceLinha, indiceColuna, linOUcol, indiceEmbarcacao);

                    if (jogadaInvalida)
                    {
                        Console.WriteLine("\n╔═════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("  ⚠ !!! Aviso: A jogada é invalida, favor inserir uma jogada valida !!! ⚠ ");
                        Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
                    }
                }
                if (!jogadaInvalida)
                    QuantEmbarcacao[indiceParaDecrementar]--;

                for (int i = 0; i < QuantEmbarcacao.Length; i++)
                {
                    if (QuantEmbarcacao[i] != 0)
                    {
                        existirEmbarc = true;
                        i = QuantEmbarcacao.Length;
                    }
                    else
                        existirEmbarc = false;
                }
            }
        }
    }

    static void exibeEmbarcUserInterna(char[,] tabuleirojogador)
    {
        Console.WriteLine("\t    0   1   2   3   4   5   6   7   8   9");
        Console.WriteLine("\t  +---------------------------------------+");
        for (int lin = 0; lin < tabuleirojogador.GetLength(0); lin++)
        {
            Console.Write($"\t{lin} | ");
            for (int col = 0; col < tabuleirojogador.GetLength(1); col++)
            {
                Console.Write($"{tabuleirojogador[lin, col]} | ");
            }
            Console.WriteLine("\n\t  +---------------------------------------+");
        }
    }

    static char[,] gerarARQmaquinaPARAmatriz()
    {
        char[] inicialEmbarcs = { 'S', 'H', 'C', 'E', 'P' };
        int[] tamEmbarcacao = { 1, 2, 3, 4, 5 };
        StreamReader arq = new StreamReader("/Users/jonathanfaulkner/Desktop/Trabalho-ATP/frotaComputador.txt", Encoding.UTF8);
        string linha = arq.ReadLine();

        string[] Split;
        char[,] tabuleiroMaquina = new char[10, 10];
        char inicial;

        while (linha != null)
        {
            Split = linha.Split(";");
            string nomeEmbarc = Split[0];
            inicial = nomeEmbarc[0];

            int indiceLinMaquina = int.Parse(Split[2]);
            int indiceColMaquina = int.Parse(Split[3]);


            int indiceEmbarcacao = 0;

            for (int i = 0; i < inicialEmbarcs.Length; i++)
            {
                if (inicial == inicialEmbarcs[i])
                    indiceEmbarcacao = i;
            }
            if (Split[1] == "h")
            {
                for (int col = indiceColMaquina; col < indiceColMaquina + tamEmbarcacao[indiceEmbarcacao]; col++)
                    tabuleiroMaquina[indiceLinMaquina, col] = inicial;
            }
            else if (Split[1] == "v")
            {
                for (int lin = indiceLinMaquina; lin < indiceLinMaquina + tamEmbarcacao[indiceEmbarcacao]; lin++)
                    tabuleiroMaquina[lin, indiceColMaquina] = inicial;
            }
            linha = arq.ReadLine();
        }
        arq.Close();
        return tabuleiroMaquina;
    }

    static int[,] jogadasRealizadasUSER()
    {
        int[,] jogadasRealizadas = new int[90, 2];
        for (int i = 0; i < jogadasRealizadas.GetLength(0); i++)
        {
            for (int j = 0; j < jogadasRealizadas.GetLength(1); j++)
            {
                jogadasRealizadas[i, j] = 10;
            }
        }
        return jogadasRealizadas;
    }

    static char[,] gerarTabuleiroUSERve()
    {
        char[,] tabuleiroUSERve = new char[10, 10];
        for (int i = 0; i < tabuleiroUSERve.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiroUSERve.GetLength(1); j++)
                tabuleiroUSERve[i, j] = '-';
        }
        return tabuleiroUSERve;
    }

    static void fazJogadaUser(string nickname, char[,] tabuleiroMaquinaMatriz, char[,] tabuleiroUSERve, int[,] jogadasRealizadas, out bool acertouTiro, out bool temEmbarcacao, int[,] pontos)
    {
        int indiceLinha = 0;
        int indiceColuna = 0;
        acertouTiro = true;
        temEmbarcacao = true;
        Console.WriteLine($"              -----------------------    ");
        Console.WriteLine($"    [----> COMEÇA AGORA AS JOGADAS <----] ");
        Console.WriteLine($"              -----------------------    \n");

        while (acertouTiro)
        {
            Console.WriteLine($"É a sua vez : [---> {nickname.ToUpper()} <---] ");
            bool jogadaJArealiza = true;
            while (jogadaJArealiza)
            {
                bool tamanhoInvalido = true;
                while (tamanhoInvalido)
                {
                    Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * \n");
                    Console.WriteLine($"Informe a jogada");
                    Console.Write($"Valor da linha é -> : ");
                    indiceLinha = int.Parse(Console.ReadLine());
                    Console.Write($"Valor da coluna é -> : ");
                    indiceColuna = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    bool tamIvalidoLinha = indiceLinha >= 0 && indiceLinha <= 9;
                    bool tamIvalidoCol = indiceColuna >= 0 && indiceColuna <= 9;

                    if (tamIvalidoLinha && tamIvalidoCol)
                        tamanhoInvalido = false;

                    else
                    {
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║  ⚠ !!! Aviso: Os valores informados estão fora dos limites de 0 a 9, Insira outros valores !!! ⚠ ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝");
                    }
                }
                jogadaJArealiza = true;
                for (int i = 0; i < jogadasRealizadas.GetLength(0); i++)
                {
                    if (indiceLinha == jogadasRealizadas[i, 0] && indiceColuna == jogadasRealizadas[i, 1])
                    {
                        jogadaJArealiza = true;
                        i = jogadasRealizadas.GetLength(0);
                    }
                    else
                        jogadaJArealiza = false;
                }
                if (!jogadaJArealiza)
                {
                    for (int i = 0; i < jogadasRealizadas.GetLength(0); i++)
                    {
                        if (jogadasRealizadas[i, 0] == 10 && jogadasRealizadas[i, 1] == 10)
                        {
                            jogadasRealizadas[i, 0] = indiceLinha;
                            jogadasRealizadas[i, 1] = indiceColuna;
                            i = jogadasRealizadas.GetLength(0);
                        }
                    }
                }
                if (jogadaJArealiza)
                {
                    Console.WriteLine("\n╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine($"║  ⚠ !!! Aviso: OS VALORES {indiceLinha} E {indiceColuna} JÁ FORAM ESCOLHIDOS ANTERIORMENTE. INSIRA OUTROS VALORES !!! ⚠ ║");
                    Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                }
            }
            realizaTIRO(tabuleiroMaquinaMatriz, tabuleiroUSERve, indiceLinha, indiceColuna, out acertouTiro, out temEmbarcacao);
            exibeEmbarcUserExterna(tabuleiroUSERve);

            if (acertouTiro)
            {
                Console.WriteLine("\n╔═══════════════════════════════════════════════════╗");
                Console.WriteLine($"  ⚠ !!! {nickname} ACERTOU O TIRO NA EMBARCAÇÃO !!! ⚠ ");
                Console.WriteLine("╚═══════════════════════════════════════════════════╝");
                pontos[0, 0]++;
            }
            else
            {
                Console.WriteLine("\n╔═════════════════════════════════════════════════╗");
                Console.WriteLine($"    ⚠ !!! {nickname} ACERTOU O TIRO NA ÁGUA !!! ⚠ ");
                Console.WriteLine("╚═════════════════════════════════════════════════╝");
            }
            imprimirPontos(pontos);
        }
    }

    static void realizaTIRO(char[,] tabuleiroMaquinaMatriz, char[,] tabuleiroUSERve, int indiceLinha, int indiceColuna, out bool acertouTiro, out bool temEbarcacao)
    {
        char[] inicialEmbarcs = { 'S', 'H', 'C', 'E', 'P' };
        int[] tamEmbarcacao = { 1, 2, 3, 4, 5 };
        char inicial = ' ';
        acertouTiro = false;

        for (int i = 0; i < inicialEmbarcs.Length; i++)
        {
            if (tabuleiroMaquinaMatriz[indiceLinha, indiceColuna] == inicialEmbarcs[i])
            {
                acertouTiro = true;
                tamEmbarcacao[i]--;
                inicial = inicialEmbarcs[i];
                i = inicialEmbarcs.Length;
            }
            else
                acertouTiro = false;
        }
        if (acertouTiro)
            tabuleiroUSERve[indiceLinha, indiceColuna] = inicial;

        else if (!acertouTiro)
            tabuleiroUSERve[indiceLinha, indiceColuna] = 'A';

        temEbarcacao = true;
        for (int i = 0; i < tamEmbarcacao.Length; i++)
        {
            if (tamEmbarcacao[i] != 0)
            {
                temEbarcacao = true;
                i = tamEmbarcacao.Length;
            }
            else
                temEbarcacao = false;
        }
    }

    static void exibeEmbarcUserExterna(char[,] tabuleiroUSERve)
    {
        Console.WriteLine("    0   1   2   3   4   5   6   7   8   9");
        Console.WriteLine("  +---------------------------------------+");
        for (int lin = 0; lin < tabuleiroUSERve.GetLength(0); lin++)
        {
            Console.Write($"{lin} | ");
            for (int col = 0; col < tabuleiroUSERve.GetLength(1); col++)
            {
                Console.Write($"{tabuleiroUSERve[lin, col]} | ");
            }
            Console.WriteLine("\n  +---------------------------------------+");
        }
        Console.WriteLine();

    }

    static int[,] jogadasRealizadasMaquina()
    {
        int[,] jogadasRealizadasMAQ = new int[90, 2];
        for (int i = 0; i < jogadasRealizadasMAQ.GetLength(0); i++)
        {
            for (int j = 0; j < jogadasRealizadasMAQ.GetLength(1); j++)
            {
                jogadasRealizadasMAQ[i, j] = 10;
            }
        }
        return jogadasRealizadasMAQ;
    }

    static char[,] gerarTabuleiroMAQUINAve()
    {
        char[,] tabuleiroMAQve = new char[10, 10];
        for (int i = 0; i < tabuleiroMAQve.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiroMAQve.GetLength(1); j++)
                tabuleiroMAQve[i, j] = '-';
        }
        return tabuleiroMAQve;
    }

    static void fazjogadasMAQ(char[,] tabuleirojogador, char[,] tabuleiroMAQve, int[,] jogadasRealizadasMAQ, out bool acertouTiro, out bool temEbarcacao, int[,] pontos)
    {
        Random posicaoRandomlinha = new Random();
        Random posicaoRandomcoluna = new Random();
        int indiceLinha = 0;
        int indiceColuna = 0;
        temEbarcacao = true;
        acertouTiro = true;

        Console.WriteLine($"              -----------------------    ");
        Console.WriteLine($"       [----> COMEÇA AGORA AS JOGADAS <----] ");
        Console.WriteLine($"              -----------------------    \n");

        while (acertouTiro)
        {
            Console.WriteLine($"É a vez da [---> MAQUINA <---] ");
            bool jogadaJArealiza = true;
            while (jogadaJArealiza)
            {
                indiceLinha = posicaoRandomlinha.Next(0, 10);
                indiceColuna = posicaoRandomcoluna.Next(0, 10);

                for (int i = 0; i < jogadasRealizadasMAQ.GetLength(0); i++)
                {
                    if (indiceLinha == jogadasRealizadasMAQ[i, 0] && indiceColuna == jogadasRealizadasMAQ[i, 1])
                    {
                        jogadaJArealiza = true;
                        i = jogadasRealizadasMAQ.GetLength(0);
                    }
                    else
                        jogadaJArealiza = false;
                }
                if (!jogadaJArealiza)
                {
                    for (int i = 0; i < jogadasRealizadasMAQ.GetLength(0); i++)
                    {
                        if (jogadasRealizadasMAQ[i, 0] == 10 && jogadasRealizadasMAQ[i, 1] == 10)
                        {
                            jogadasRealizadasMAQ[i, 0] = indiceLinha;
                            jogadasRealizadasMAQ[i, 1] = indiceColuna;
                            i = jogadasRealizadasMAQ.GetLength(0);
                        }
                    }
                }
            }
            realizaTIRO(tabuleirojogador, tabuleiroMAQve, indiceLinha, indiceColuna, out acertouTiro, out temEbarcacao);
            exibeEmbarcUserExterna(tabuleiroMAQve);

            if (acertouTiro)
            {
                Console.WriteLine("\n╔═════════════════════════════════════════════════════════╗");
                Console.WriteLine($"   ⚠ !!! A MAQUINA --> ACERTOU O TIRO NA EMBARCAÇÃO !!! ⚠ ");
                Console.WriteLine("╚═════════════════════════════════════════════════════════╝");
                pontos[0, 1]++;
            }
            else
            {
                Console.WriteLine("\n╔══════════════════════════════════════════════════╗");
                Console.WriteLine($"  ⚠ !!! A MAQUINA --> ACERTOU O TIRO NA ÁGUA !!! ⚠ ");
                Console.WriteLine("╚══════════════════════════════════════════════════╝");
            }

            imprimirPontos(pontos);
        }
    }

    static void sequenciaTIROSvencedor(int[,] jogadasRealizadasVencedor, string nomeVencedor)
    {
        StreamWriter arq = new StreamWriter("/Users/jonathanfaulkner/Desktop/Trabalho-ATP/jogadas.txt", false, Encoding.UTF8);

        arq.WriteLine($"JOGADAS DO {nomeVencedor}\n\n");
        for (int i = 0; i < jogadasRealizadasVencedor.GetLength(0); i++)
        {
            for (int j = 0; j < jogadasRealizadasVencedor.GetLength(1); j++)
            {
                if (jogadasRealizadasVencedor[i, j] != 10)
                    arq.Write(jogadasRealizadasVencedor[i, j] + ",");
            }
            arq.WriteLine();
        }
        arq.Close();
    }

    static void imprimirPontos(int[,] pontos)
    {
        Console.WriteLine("\t------>.PONTUAÇÃO.<-----");
        Console.WriteLine("\t\t╔═══════╗");
        Console.WriteLine($"\t\t║ {pontos[0, 0]} ║ {pontos[0, 1]} ║");
        Console.WriteLine("\t\t╚═══════╝");
        Console.WriteLine("\t* * * * * * * * * * * * * ");
    }

    static void Main(string[] args)
    {
        char[,] matPosicioesEmbarcMAQ = criarTabuleiroMaquina();
        gerarArquivoMaquina(matPosicioesEmbarcMAQ);

        char[,] tabuleirojogador = criarMatrizJogador();
        string nickname = criarNickname();
        posicionarEmbarcUSER(tabuleirojogador, nickname);

        matPosicioesEmbarcMAQ = gerarARQmaquinaPARAmatriz();

        char[,] tabuleiroUSERve = gerarTabuleiroUSERve();
        int[,] jogadaRealizadasUSER = jogadasRealizadasUSER();

        char[,] tabuleiroMAQve = gerarTabuleiroMAQUINAve();
        int[,] jogadasRealizadasMAQ = jogadasRealizadasMaquina();

        bool userAcertouaJogada;
        bool maquinaAcertouJogada;
        bool userTemEmbarcacao = false;
        bool maqTemEmbarcacao = false;
        bool jogoGERALencerrou = false;
        int[,] pontos = new int[1, 2];   

        while (!jogoGERALencerrou)
        {
            userAcertouaJogada = true;
            while (userAcertouaJogada)
                fazJogadaUser(nickname, matPosicioesEmbarcMAQ, tabuleiroUSERve, jogadaRealizadasUSER, out userAcertouaJogada, out userTemEmbarcacao, pontos);

            maquinaAcertouJogada = true;
            while (maquinaAcertouJogada)
                fazjogadasMAQ(tabuleirojogador, tabuleiroMAQve, jogadasRealizadasMAQ, out maquinaAcertouJogada, out maqTemEmbarcacao, pontos);

            if (!userTemEmbarcacao || !maqTemEmbarcacao)
                jogoGERALencerrou = true;
        }
        if (!userTemEmbarcacao)
        {
            Console.WriteLine("\n╔═════════════════════════════════════════╗");
            Console.WriteLine($"  !!! {nickname.ToUpper()} VOCÊ GANHOU - PARABÉNS !!!  ");
            Console.WriteLine("╚═════════════════════════════════════════╝");
            sequenciaTIROSvencedor(jogadaRealizadasUSER, nickname);
        }
        else if (!maqTemEmbarcacao)
        {
            Console.WriteLine("\n╔════════════════════════════╗");
            Console.WriteLine($"║ !!! A MAQUINA GANHOU  !!!  ║");
            Console.WriteLine("╚════════════════════════════╝");
            sequenciaTIROSvencedor(jogadasRealizadasMAQ, "MAQUINA");
        }
        Console.ReadLine();
    }
}

