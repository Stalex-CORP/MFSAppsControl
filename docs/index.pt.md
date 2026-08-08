# MFSAppsControl

## Descrição

O **MFSAppsControl** é uma aplicação que permite **iniciar e/ou parar** aplicações de terceiros monitorizando o estado do Microsoft Flight Simulator 2024/2020.<br>
Deixe de iniciar as suas aplicações uma a uma antes de cada voo: configure-as uma vez e o MFSAppsControl trata de tudo.

![O ecrã principal do MFSAppsControl](assets/main-screen.png)

## Como funciona

O MFSAppsControl acompanha o seu voo de ponta a ponta, em **três fases**:

::timeline::

- title: Arranque do simulador
  content: As aplicações configuradas em **Início do sim** arrancam assim que o simulador é iniciado, respeitando o atraso definido.
  icon: ' :material-numeric-1: '

- title: Ecrã "Pronto para voar"
  content: As aplicações configuradas em **Pronto para voar** arrancam assim que aparece o botão \"Pronto para voar\", respeitando o atraso definido.
  icon: ' :material-numeric-2: '

- title: Encerramento do simulador
  content: As aplicações configuradas em **Paragem auto** fecham de forma limpa ao fechar o simulador.
  icon: ' :material-numeric-3: '

::/timeline::


**A diferença entre os dois tipos de arranque é o coração da aplicação:**<br>
Algumas aplicações podem:

- Ser iniciadas **logo no arranque** do simulador (ex.: Navigraph, Volanta…)
- Ter restrições/só serem úteis **durante um voo** (ex.: REX Atmos, FS2Crew…)

Deve escolher o que melhor corresponde a cada aplicação. → [Aplicações e sequência](applications.md#os-dois-acionadores-de-arranque)

## As funcionalidades

<div class="grid cards" markdown>

- <span style="color: var(--md-accent-fg-color)">:material-rocket-launch: **Sequência automática**</span><br>
  Cada aplicação arranca conforme o seu acionador, depois do atraso definido, visualizado diretamente na linha temporal para perceber a ordem de arranque.

- <span style="color: var(--md-accent-fg-color)">:material-folder-multiple: **Perfis**</span><br>
  Agrupe as suas aplicações por utilização (A320, VFR, carga…) e alterne com um clique. O perfil apresentado é o perfil ativo.

- <span style="color: var(--md-accent-fg-color)">:material-tray-arrow-down: **Discreto**</span><br>
  Pode ser minimizado na área de notificação e arrancar com o Windows, para estar pronto a qualquer momento nos seus próximos voos sem pensar nisso.

- <span style="color: var(--md-accent-fg-color)">:material-translate: **Interface totalmente multilingue**</span><br>
  Totalmente traduzida para francês, inglês, alemão, espanhol, italiano e português, com mudança em direto e persistência na configuração.

- <span style="color: var(--md-accent-fg-color)">:material-shield-check: **Aplicações de administrador**</span><br>
  Detetadas automaticamente ao adicionar, com um pedido do Windows. Só as aplicações que precisam de privilégios de administrador usarão o modo de administrador.

- <span style="color: var(--md-accent-fg-color)">:material-flask: **Modo de teste**</span><br>
  Reproduza toda a sequência (incluindo o acionador «pronto para voar») sem iniciar o simulador, para verificar os seus perfis.

</div>

## Por onde começar?

1. [**Instalação**](installation.md) — transferir e instalar a aplicação.
2. [**Introdução**](getting-started.md) — configure a sua primeira sequência.
3. [**Aplicações e sequência**](applications.md) — o detalhe das diferentes partes da aplicação.
4. [**Perfis**](profiles.md) e [**Opções**](options.md) — faça a gestão dos seus perfis e definições.
5. [**FAQ**](faq.md) — as perguntas mais frequentes.
6. [**Suporte**](support.md) — para necessidades de assistência.
