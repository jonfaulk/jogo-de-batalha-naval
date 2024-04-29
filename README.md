JOGO DESENVOLVIDO PARA CONCLUSÃO DE SEMESTRE.

JOGO SE TRATA DE UM CÓDIGO INTEIRAMENTE FEITO POR BACK END, A INTERAÇÃO É PELO CONSOLE.

SEGUE ABAIXO O QUE FOI EXIGIDO.

O trabalho consiste no desenvolvimento de uma versão simplificada do jogo batalha naval. Este jogo é jogado em um
tabuleiro com N linhas e M colunas. Cada posição desse tabuleiro é um quadrado que pode conter água ou parte de um
navio. Um jogador informa ao outro a posição (linha, coluna) do quadrado alvo do disparo. O jogo termina quando um
dos jogadores afunda todas as embarcações do seu oponente. Desenvolva um jogo de batalha naval, em que um
jogadorHumano dispute contra o computador (jogadorComputador).
Exemplo do jogo Batalha Naval:
Jogo Batalha Naval Clássico no Jogos 360
1) O programa deverá gerar um tabuleiro para o jogadorComputador com 10 linhas e 10 colunas. O programa deverá
ler de um arquivo (frotaComputador.txt) a posição das embarcações. (Considere que sempre serão informadas
posições válidas)As embarcações podem ser posicionais na horizontal ou vertical. A tabela a seguir descreve as
opções de embarcações e as quantidades que devem ser colocadas em cada tabuleiro:
Embarcação Quantidade Representação no tabuleiro
Submarino 4 S
Hidroavião 3 HH
Cruzador 2 CCC
Encouraçado 1 EEEE
Porta-aviões 1 PPPPP
Exemplo de um tabuleiro com todas as embarcações:
0 1 2 3 4 5 6 7 8 9
0 A A A A A S A A A S
1 H H A S A A A A A A
2 A A A A A A A A A A
3 A A A A H A C A A A
4 A A A A H A C A A A
5 A C C C A A C A A A
6 E A A A A S A A A A
7 E A A A A A A A H H
8 E A A A A A A A A A
9 E A A A A P P P P P
Legenda:
• A: água
Exemplo arquivo frotaComputador.txt
Porta-aviões;h;9;5
Encouraçado;v;6;0
Cruzador;h;5;1
Cruzador;v;3;6
Hidroavião;h;1;0
Hidroavião;v;3;4
Hidroavião;h;7;8
Submarino;h; 0;5
Submarino;h;0;9
Submarino;h;1;3
Submarino;h;6;5
2) O jogadorHumano deverá informar seu nome completo e o programa deverá gerar um nickname (apelido) para ele
com o primeiro nome e as iniciais dos demais nomes (nomes do meio e último nome). Esse nickname deve ser
usado pelo programa em todas as mensagens dirigidas ao jogadorHumano.
3) O tabuleiro do jogadorHumano terá 10 linhas e 10 colunas. O jogadorHumano deverá escolher (via teclado) as
posições das seguintes embarcações:
Embarcação Quantidade Representação no tabuleiro
Submarino 4 S
Hidroavião 3 HH
Cruzador 2 CCC
Encouraçado 1 EEEE
Porta-aviões 1 PPPPP
Caso seja informada uma posição que não caiba a embarcação inteira, o programa deverá solicitar que seja informada
uma nova posição. Esse processo deve ser repetido até que seja informada uma posição válida. O programa não deve
permitir que duas embarcações sejam posicionadas na mesma posição.
4) Após posicionar as embarcações, o jogo terá as seguintes etapas:
• O programa deverá mostrar o estado atual do tabuleiro do jogadorComputador (sem mostrar, é claro, as posições
das embarcações). O jogadorHumano disparará um tiro, indicando (via teclado) a posição do alvo por meio dos
números da linha e da coluna que definem a posição no tabuleiro. O programa deverá informar se o tiro acertou
alguma embarcação e deverá mostrar o estado atual do tabuleiro, isto é, mostrar o tabuleiro indicando os tiros feitos
na água e os tiros que acertaram as embarcações. Caso o tiro tenha acertado a água, a vez de jogar passa para o
JogadorComputador. Caso contrário, o jogadorHumano poderá dar novos tiros enquanto ele estiver acertando partes
de embarcações do seu oponente. (Obs: Cada disparo que um jogador faz deve ser feito em um dos quadrados do
tabuleiro do outro jogador. Se um jogador informar uma posição fora dos limites do tabuleiro, deve ser solicitada
uma nova posição de disparo. Cada jogador não pode atirar no mesmo lugar mais de uma vez. Se um jogador
informar uma posição de disparo que já foi utilizada anteriormente, o programa deve solicitar uma nova posição de
disparo).
• O JogadorComputador, na sua vez de jogar, seguirá o seguinte procedimento: O programa deverá mostrar o estado
atual do tabuleiro do jogadorHumano (sem mostrar, é claro, as posições das embarcações). Na vez do
JogadorComputador o programa deverá escolher aleatoriamente as coordenadas da posição alvo (linha e coluna).
O programa deverá informar se o tiro acertou ou não uma embarcação e mostrar o estado atual do tabuleiro do
jogadorHumano. Caso o tiro tenha acertado a água, a vez de jogar passa para o JogadorHumano. Caso contrário, o
jogadorComputador poderá dar novos tiros enquanto ele estiver acertando partes das embarcações do seu oponente.
(obs: Cada disparo que um jogador faz deve ser feito em um dos quadrados do tabuleiro do outro jogador. Assim,
deve ser sorteada uma posição dentro dos limites do tabuleiro. Se for informada uma posição de disparo que já foi
utilizada anteriormente, o programa deve sortear uma nova posição de disparo, até que uma posição válida seja
sorteada).
0 1 2 3 4 5 6 7 8 9
0 A T T A A A A A A A
1 A A A A A A A A A A
2 A A A A A A A A A A
3 A A A A A A A A A A
4 A A A A A A A A A A
5 A A A A A A A A A A
6 A A A A A A A A A A
7 A A A A A A A A A A
8 A A A X A A A A A A
9 A A A X A A A A A A
Legenda:
• A: água
• T: tiro acertou parte de uma embarcação
• X: tiro acertou na água
• Cada jogador ganhará um ponto para cada tiro que acertar parte da embarcação do seu oponente. O jogo
terminará quando um jogador atingir a pontuação máxima do jogo, isto é, quando todas as embarcações de seu
oponente forem afundadas. O programa deve informar qual jogador venceu o jogo. Se o jogadorHumano que
tiver vencido, deve ser informado seu nickname.
• Por fim, o programa deve escrever em um arquivo texto (jogadas.txt) a sequência de tiros do jogador vencedor,
isto é, escrever as posições (linha e coluna) dos tiros na ordem em que eles foram feitos.
o Exemplo: Tiro 1: (0, 1)
Tiro 2: (8, 3)
