# Resolução de problemas (FAQ)

## Deteção do simulador

??? question "O MSFS não é detetado"
    O MFSAppsControl monitoriza os processos `FlightSimulator2024.exe` (MSFS 2024)
    e `FlightSimulator.exe` (MSFS 2020). Certifique-se de que o simulador está mesmo iniciado.<br>
    A passagem a «em execução» demora alguns segundos após o arranque do MSFS.

??? question "Iniciei o MFSAppsControl com o MSFS já em execução, e não acontece nada"
    É **intencional**. Se o simulador já estiver presente no arranque da
    aplicação, a sequência não é acionada: caso contrário, abrir o
    MFSAppsControl a meio de um voo voltaria a iniciar aplicações indesejadas.

    Armar-se-á automaticamente no próximo arranque. Entretanto, pode
    iniciar uma aplicação à mão através do menu **⋯** do seu cartão.

??? question "O indicador do SimConnect fica cinzento apesar de o MSFS estar em execução"
    O MFSAppsControl só tenta a ligação **quando o simulador está iniciado**,
    e depois tenta novamente com regularidade. Alguns segundos de espera são normais
    no arranque do MSFS.

    Se ficar cinzento durante muito tempo:

    - verifique se o simulador terminou o arranque (o SimConnect só está disponível
      quando o simulador está realmente inicializado, e durante o ecrã de carregamento);
    - verifique se nenhum antivírus ou firewall está a bloquear o MFSAppsControl;

    Ao fim de muito tempo sem ligação enquanto o MSFS está em execução, o indicador passa a
    **vermelho** («SimConnect indisponível») para assinalar o problema.

    Sem o SimConnect, o acionador «pronto para voar» não funciona.

## Arranque das aplicações

??? question "Uma aplicação não inicia"
    - Verifique se o seu cartão não está em **erro** (passe o rato sobre o emblema para ler a mensagem de erro).
    - Verifique se há mesmo um **acionador** ativo (:material-play: ou :material-airplane:). Se nenhum dos dois estiver aceso, a aplicação nunca é iniciada automaticamente.
    - Se o acionador for **Pronto para voar**, a aplicação só arrancará a partir do ecrã "Pronto para voar" — e apenas se o **SimConnect estiver ligado**.
    - Se a aplicação mostrar um **escudo** :material-shield-alert:, requer direitos de administrador (ver abaixo).
    - Use **Testar** para reproduzir a sequência sem iniciar o MSFS e observar o estado de cada cartão.

??? question "As aplicações «pronto para voar» nunca iniciam"

    Por ordem:

    1. O indicador **SimConnect ligado** está verde durante o voo?
    2. O botão :material-airplane: está mesmo ativo no cartão (e não o :material-play:)?
    3. Já voou nesta sessão? As aplicações «pronto para voar» só iniciam **uma vez por sessão de simulador** — não voltam a arrancar entre dois voos.

    Para revalidar tudo sem voar, use o botão **Testar**: simula o SimConnect ao fim de 10 segundos.

??? question "As minhas aplicações «pronto para voar» arrancam demasiado cedo"
    É o comportamento esperado. O acionamento ocorre assim que o ecrã "Pronto para voar" aparece, após o carregamento.

    Adicione um **atraso** no cartão para adiar o seu arranque esses segundos a contar desse momento.

??? question "A aplicação pede direitos de administrador (UAC)"
    Algumas aplicações (Active Sky, REX Atmos…) exigem administrador. Para as
    iniciar — e para as **parar** — o MFSAppsControl tem de estar elevado. Quando um
    add-on deste tipo está presente no perfil ativo, a aplicação reinicia
    automaticamente como administrador (**um único** pedido de UAC).

    **As outras aplicações não herdam esses direitos**: cada uma arranca com
    os que o seu próprio executável exige. O vPilot ou o Navigraph correm como
    utilizador normal mesmo quando o MFSAppsControl está elevado.

    Se recusar o pedido, tudo o resto continua a funcionar, mas essas
    aplicações falharão com o erro «requer direitos de
    administrador».

??? question "Uma aplicação inicia à frente do simulador"
    Ative **Iniciar minimizada** :material-arrow-collapse: no seu cartão: será
    iniciada numa janela minimizada, sem passar à frente do MSFS. O MFSAppsControl segue
    também as janelas dos **subprocessos** da aplicação (algumas, como o
    FS2Crew, abrem a sua interface através de outro processo).

    Alguns raros programas com janela personalizada forçam mesmo assim a sua janela
    para primeiro plano. Por vezes é uma opção disponível na própria aplicação, por vezes um comportamento interno da aplicação que não pode ser contornado.

??? question "As minhas aplicações não fecham quando saio do MSFS"
    Verifique se o botão **Paragem auto** :material-square: está ativo no seu
    cartão — é **independente** do arranque automático — e se o seu MSFS está mesmo fechado (Gestor de Tarefas).

    O MFSAppsControl pede primeiro um **fecho limpo** e depois **força a paragem**
    dos processos que permaneçam ativos — incluindo algumas aplicações que continuam a correr em segundo plano depois de fechar a sua janela.

    Se a aplicação requer direitos de administrador, o MFSAppsControl também tem de estar elevado para a poder parar (ver acima).

??? question "Uma aplicação aparece «EM EXECUÇÃO» apesar de eu não a ter iniciado a partir do MFSAppsControl"
    É normal: o MFSAppsControl verifica regularmente que processos estão realmente
    em execução e **adota** os que correspondem às suas aplicações configuradas. Assim a visualização mantém-se fiel, quer inicie as suas
    aplicações a partir do MFSAppsControl quer à mão.

    Passe o rato sobre o emblema para ver o **PID** do processo em questão.

## Interface

??? question "Porque é que o atraso está a cinzento?"
    Porque não foi escolhido nenhum **arranque automático** para esta aplicação. Ative :material-play: ou :material-airplane: e volta a ser ajustável.

??? question "Porque é que aparece o cadeado e os botões estão a cinzento durante o voo?"
    Assim que o simulador é detetado, a configuração dos cartões e os perfis ficam **bloqueados**: alterar uma sequência durante o seu decurso
    (ou mudar de perfil a meio do voo) seria complexo de gerir.

    O menu **⋯** continua disponível para iniciar ou parar uma aplicação manualmente.

??? question "Porque é que não posso desativar a paragem auto numa aplicação «pronto para voar»?"
    Uma aplicação iniciada para o voo não tem qualquer razão para sobreviver ao simulador: por isso a paragem automática está **bloqueada na posição ativa** para este acionador.<br>
    Volte a colocar o cartão em **Início do sim** se quiser mantê-la aberta depois do voo.

??? question "Como fechar mesmo a aplicação quando ela está na área de notificação?"
    Se a opção **Fechar minimiza para a bandeja do sistema** estiver ativada, a cruz oculta a janela em vez de encerrar.<br>
    Clique com o **botão direito no ícone** da área de notificação → **Sair**.<br>
    Caso contrário, use simplesmente a cruz da janela para fechar a aplicação.

??? question "A janela abriu-se fora do ecrã / demasiado pequena"
    O MFSAppsControl memoriza a posição da janela. Em caso de problema de visualização (por exemplo após uma mudança de monitor), mova ou redimensione a janela: a nova posição será memorizada.<br><br>
    **Dica prática**<br>
    Use " ++windows++ + seta esquerda " ou " ++windows++ + seta direita " para a deslocar pelas zonas dos ecrãs.

## Dados e manutenção

??? question "Onde são guardados os meus perfis e definições?"
    Num único ficheiro:
    `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\settings.json`<br>
    (ou seja, `C:\Users\<você>\AppData\Local\Stalex CORP\MFSAppsControl\`).

    Este ficheiro é **cifrado**: não é modificável diretamente. Para
    o guardar, copie-o tal como está.
    → [Perfis](profiles.md)

??? question "Onde estão os registos (logs)?"
    Em `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\logs`. (Um ficheiro por dia, conservados **7 dias**).<br>
    **Para os enviar ao suporte:**<br>
    **Opções → Depuração → Exportar registos**, que produz um `.zip` completo (registos + configuração). → [Suporte](support.md)

??? question "Como recomeçar do zero?"
    **Opções → Depuração → Repor a aplicação** apaga tudo e repõe a aplicação no seu estado de instalação.<br>
    **Esta ação é irreversível** — copie primeiro o seu `settings.json` se for necessário.

??? question "Posso usar o MFSAppsControl com o MSFS 2020?"
    Sim, ambas as versões (2024 e 2020) são suportadas, incluindo a
    deteção «pronto para voar». Um mesmo perfil funciona seja qual for a versão.

??? question "Como atualizar a aplicação?"
    Quando há uma atualização disponível, aparece um **emblema** na barra de
    título. Clique nele para transferir e instalar a nova versão.<br>
    Os seus perfis e definições são conservados.

!!! info "Ainda bloqueado?"
    Coloque a sua questão no [**Discord**](support.md), no canal dedicado
    **#mfsappscontrol** — anexando o zip que exportou.
