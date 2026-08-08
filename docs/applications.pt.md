# Aplicações e sequência

Cada aplicação do seu perfil é apresentada sob a forma de um **cartão**.<br>
Esta página detalha como as adicionar, como as configurar e como ler a **sequência de arranque**.

---

## Adicionar uma aplicação

Clique em **Adicionar uma aplicação** na grelha. Dois modos:

=== "Aplicações instaladas"

    Lista os programas já instalados (através do registo do Windows).<br>
    Procure-a e selecione-a: o nome, o ícone e o caminho são recuperados automaticamente.

    ![Modo aplicações instaladas](assets/add-app-installed.png)

    !!! note "A lista é filtrada de propósito"
        Para se manter legível, a lista exclui os programas sem relação com o voo
        (controladores e utilitários do sistema, navegadores, jogos, lançadores, etc.) e
        oculta as aplicações **já presentes no perfil ativo**. Uma
        aplicação instalada normalmente que não apareça — ou um programa
        **portátil** — pode sempre ser adicionada através do separador **Procurar**.

=== "Procurar"

    Indique o caminho de um `.exe`, ou clique em **Procurar** para a selecionar: o nome e o ícone são recuperados automaticamente.

    ![Modo procurar](assets/add-app-browse.png)

    !!! note "Utilização"
        Este modo destina-se às aplicações **portáteis** (não instaladas) ou não detetadas, que não aparecem no registo do Windows.

A janela de adição contém depois os **argumentos de arranque**, o **acionador**, o **atraso** e a opção **Iniciar minimizada**, todos modificáveis após a adição.

---

## Anatomia de um cartão

![Cartão de uma aplicação](assets/app-card.png)

**Em cima** encontra as informações da aplicação:

- O ícone da aplicação
- O seu **nome**
- O seu **caminho**
- Os seus **argumentos** (por baixo do caminho, quando definidos).

À direita, o **emblema de estado** (visível durante a execução) e o menu **:material-dots-horizontal:**.

**Em baixo, a barra de controlo**, acessível com um clique:

| Controlo                                          | Função                                                                                                                  |
| ------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| :material-play: **Início do sim**                 | Inicia ao arrancar o simulador.                                                                                         |
| :material-airplane: **Pronto para voar**          | Inicia quando o ecrã **Pronto para voar** é apresentado.                                                                |
| :material-arrow-collapse: **Iniciar minimizada**  | Inicia a aplicação numa janela minimizada.<br>*Visível apenas se estiver escolhido um arranque automático*             |
| :material-square: **Paragem auto**                | Fecha a aplicação quando o simulador para.<br>*Ativado e bloqueado automaticamente com o arranque "Pronto para voar"* |
| :material-minus::material-plus: **Atraso**        | Tempo de espera antes do arranque desta aplicação, consoante o modo de arranque.                                        |

Estas definições estão igualmente presentes na janela de modificação.

### Os dois acionadores de arranque

É a definição mais útil do MFSAppsControl.<br>
Os dois botões da esquerda (:material-play: e :material-airplane:) formam uma **escolha única**: ativar um desativa o outro, e voltar a clicar no que está ativo **desativa o arranque automático**.

|                       | :material-play: **Início do sim**              | :material-airplane: **Pronto para voar**      |
| --------------------- | ---------------------------------------------- | --------------------------------------------- |
| **É acionado**        | Quando o **processo** do MSFS é detetado       | Quando o seu **avião aparece no mundo**       |
| **Deteção**           | Por **monitorização do processo**              | Através do **SimConnect**                     |
| **O atraso começa**   | A partir do arranque do simulador              | A partir do ecrã "Pronto para voar"           |
| **Normalmente para**  | Navigraph, vPilot, um utilitário de hardware   | REX Atmos, FS2Crew, ferramentas de avião      |

!!! tip "Como escolher?"
    Faça as perguntas certas:<br>
    *«Esta aplicação tem de estar pronta/disponível antes de eu começar a voar?»*<br>
    *«Esta aplicação funciona sem o simulador?»*<br>
    *«Esta aplicação não interfere com o funcionamento do meu simulador?»*<br>

    - **Sim** → Início do sim. Tem de estar pronta antes de o voo começar.
    - **Não** → Pronto para voar. Não vale a pena pô-la a correr antes de estar no voo.

**O que deve saber sobre o arranque «Pronto para voar»**

!!! info "A paragem auto está bloqueada"
    Uma aplicação «pronto para voar» fecha **sempre** com o simulador: o botão :material-square: está bloqueado na posição ativa.<br>
    Uma aplicação iniciada para o voo não tem qualquer razão para sobreviver ao simulador.

!!! info "O acionamento ocorre no ecrã «Pronto para voar»"
    Em concreto, isto acontece logo após o carregamento de um voo, assim que o ecrã "Pronto para voar" é apresentado.
    É a única deteção segura possível para detetar um voo "corretamente".

!!! warning "O SimConnect tem de estar ligado"
    **Este acionador assenta no SimConnect**.<br>
    Se o estado do SimConnect não estiver **verde** (SimConnect ligado), as aplicações «pronto para voar» não arrancarão.<br>
    Se ficar muito tempo sem se ligar, passa a **vermelho** («SimConnect indisponível»). → [Resolução de problemas](faq.md)

### A paragem automática

O botão :material-square: **Paragem auto** fecha a aplicação quando o simulador para.<br>
É **independente** do arranque: pode ter uma aplicação que inicia à mão ou por outro meio, mas que o MFSAppsControl fecha com o simulador.

O fecho é **limpo**: o MFSAppsControl tenta primeiro fechar a aplicação como se clicasse na cruz, dá-lhe alguns segundos para terminar a sua sessão e só força o fecho como último recurso.<br>
As aplicações que precisam de se desligar de forma limpa (por exemplo o Active Sky) são assim tratadas corretamente.

### Iniciar minimizada

A opção :material-arrow-collapse: **Iniciar minimizada** inicia a aplicação numa **janela minimizada**, útil quando esta não precisa de ser apresentada em primeiro plano.

O botão só aparece se estiver escolhido um **arranque automático**.

!!! note
    Algumas aplicações forçam a sua janela para primeiro plano alguns segundos após o arranque.<br>
    O MFSAppsControl tenta minimizá-las durante alguns segundos, mas alguns raros programas conseguem resistir.

### O atraso

O **atraso** é o tempo de espera antes do arranque da aplicação, **a partir do seu acionador**. Permite **espaçar** os arranques.

- Ajustável de **0 a 600 segundos** (10 minutos)
- Os botões **−** / **+** alteram o valor em passos de **5 s**; também pode **escrever** diretamente o valor
- O atraso fica **a cinzento** se não estiver escolhido nenhum arranque automático
- Durante um voo, mostra um **cadeado** :material-lock: — a configuração está bloqueada

!!! tip "Os dois acionadores têm a sua própria sequência"
    Um atraso de 30 s numa aplicação «início do sim» = 30 s após o arranque do MSFS. <br>
    Um atraso de 30 s numa aplicação «pronto para voar» = 30 s após o aparecimento do ecrã "Pronto para voar".

### Os argumentos de arranque

Campo opcional: os parâmetros de linha de comandos passados ao executável, separados por espaços (ex.: `--auto`).<br>
São apresentados no cartão, por baixo do caminho.

A aplicação é sempre iniciada a partir da **sua própria pasta de instalação**.

---

## A linha temporal

O centro do painel mostra a **sequência de arranque**: que aplicação arranca em que momento.<br>
Aparece assim que pelo menos uma aplicação tiver arranque automático.

![A linha temporal da sequência de arranque](assets/timeline-dual.png)

Cada bloco representa um momento de arranque, com os ícones das aplicações em causa.<br>
Passe o rato sobre um bloco para ver os nomes e o respetivo estado.

Como os dois acionadores são independentes, a linha temporal mostra **duas faixas**:

- Uma faixa para «início do sim»
- Uma faixa para «pronto para voar».

### Dois estilos de visualização possíveis

Nas [Opções](options.md) → **Aparência** → **Estilo da sequência**, pode escolher a representação que mais lhe agradar:

- **Duplo** — Duas faixas individuais, uma para cada sequência
- **Mono** — Uma única faixa dividida ao meio, uma metade para cada sequência

## Os estados de um cartão

O **contorno** do cartão e o seu **emblema** indicam o estado da aplicação

|                          Emblema                          | Contorno | Significado                                                            |
| :-------------------------------------------------------: | :------: | ---------------------------------------------------------------------- |
| ![Emblema de contagem decrescente](assets/badge-countdown.png) |   azul   | O atraso está em curso.<br>O emblema mostra os segundos restantes. |
|      ![Emblema em execução](assets/badge-running.png)      |  verde   | O processo está iniciado.                                              |
|         ![Emblema de erro](assets/badge-error.png)         | vermelho | O arranque falhou.                                                     |
|                     *sem emblema*                          |          | Aplicação parada/inativa.                                              |

**Passe o rato sobre um emblema** para obter mais detalhes: o emblema de erro indica a causa (executável não encontrado, direitos de administrador necessários…) e o emblema verde mostra o **PID** do processo.

### Cancelar um arranque

Durante uma contagem decrescente, aparece uma cruz **✕** ao lado do emblema. Permite **cancelar o arranque** apenas dessa aplicação. As outras prosseguem normalmente a sua sequência.

### Aplicações iniciadas fora do programa

O MFSAppsControl verifica regularmente que processos estão realmente em execução.<br>
Se iniciar você mesmo uma aplicação configurada (ou se a fechar), o seu cartão atualiza-se.<br>
Passa a **EM EXECUÇÃO verde** sem que o MFSAppsControl a tenha iniciado.

Neste caso, a dica do emblema mostra o **PID** do processo adotado:

```
Processo ativo
PID 24680
```

## Modificar ou agir sobre uma aplicação

Abra o menu **:material-dots-horizontal:** do cartão, ou clique com o **botão direito**:

| Entrada                                     | Efeito                                                        |
| ------------------------------------------- | --------------------------------------------------------------- |
| :material-square-edit-outline: **Editar**   | Reabre a janela de definições, pré-preenchida.                |
| :material-play: **Iniciar agora**           | Inicia a aplicação imediatamente, sem atraso.                 |
| :material-stop-circle: **Parar**            | Para o processo em curso (substitui «Iniciar agora»).         |
| :material-delete: **Remover da lista**      | Elimina a aplicação do perfil.                                |

![Modificar uma aplicação](assets/app-editmenu.png)

## Filtrar e ordenar

A barra por cima da grelha oferece dois menus:

- **Filtrar** — *Todas*, *Arranque do MSFS* (aplicações com arranque automático),
  *Encerramento do MSFS* (aplicações com paragem automática), *Pronto para voar* (aplicações com o
  acionador SimConnect).
- **Ordenar** — por *Nome* (alfabético) ou por *Atraso* (crescente).

Estas definições alteram **apenas a visualização** e não afetam nem a sequência de arranque nem o perfil.

![Filtrar e ordenar](assets/app-filters.png)

## Durante o voo, a configuração está bloqueada

Assim que o simulador é detetado, o perfil e as aplicações ficam **bloqueados** (cadeado :material-lock:{ style="color:#3ecf8e" }).<br>

Pode sempre **iniciar** ou **parar** uma aplicação à mão através do menu **:material-dots-horizontal:**.

## Aplicações que requerem administrador

Algumas aplicações exigem **direitos de administrador** (por exemplo o Active Sky, o REX Atmos).<br>
Mostram um **escudo** <span style="color:red;">:material-shield-alert:</span> ao lado do seu nome.

Quando existe uma aplicação deste tipo no perfil ativo, ser-lhe-á pedido que **reinicie como administrador** no arranque ou ao adicioná-la, através de **um único** pedido de UAC.

!!! info "Só as aplicações que o exigem são elevadas"
    Mesmo quando o MFSAppsControl corre como administrador, **não** transmite esses direitos a tudo o que inicia.<br>
    Cada aplicação arranca com os direitos que o **seu próprio executável** exige; só as que precisam realmente de administrador o recebem.

!!! tip "Se recusar a elevação"
    O MFSAppsControl continua a funcionar normalmente, mas as aplicações de administrador **não serão iniciadas**.<br>
    O seu cartão mostrará o erro «requer direitos de administrador».<br>
    Também não conseguirá fechá-las ao encerrar o simulador.

## Caminho inválido/Erro de arranque

Se o executável de uma aplicação for **impossível de encontrar** (movido/desinstalado), ou se ocorrer um erro na execução, o seu cartão passa a **erro vermelho**, com o detalhe do erro nas informações do emblema.

Essa aplicação fica então:

- **ignorada pela sequência de arranque** (nenhuma tentativa de arranque);
- **excluída da deteção de processos**.

## Testar a sequência

O botão **Testar** reproduz **toda** a sequência sem iniciar o simulador.<br>
Trata-se apenas de uma simulação do arranque/encerramento do simulador: as suas aplicações são realmente iniciadas.

O decurso é o seguinte:

1. O estado passa ao estado «simulador detetado» azul.
2. Ao fim de **5 s**, o estado passa a «em execução». A sequência **Início do sim** é acionada segundo os atrasos configurados, com o **SimConnect ligado**, tal como numa sessão real, em que o SimConnect fica ativo durante o carregamento.
3. Uma contagem decrescente **«Pronto para voar em 10s…»\*** aparece sob o botão: é o tempo simulado para chegar ao ecrã «Pronto para voar».<br> **\*** A contagem decrescente só aparece se o seu perfil contiver pelo menos uma aplicação **Pronto para voar** válida.
4. No final desse tempo, a sequência **Pronto para voar** é acionada por sua vez, segundo os atrasos configurados.

O botão passa a **Parar** logo desde o início: clique nele para terminar o teste e fechar todas as aplicações com paragem auto que já estejam iniciadas.<br>
Fica **bloqueado** durante o fecho — algumas aplicações demoram alguns segundos a fechar corretamente — e depois volta a **Testar**.

!!! note
    Atenção: as aplicações já iniciadas antes do teste também serão **fechadas** se estiverem configuradas para a paragem automática. O teste não distingue entre as aplicações iniciadas pelo MFSAppsControl e as iniciadas manualmente.
