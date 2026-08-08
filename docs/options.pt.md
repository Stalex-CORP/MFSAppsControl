# Opções

Abra as opções com o ícone de **engrenagem** :material-cog: da barra de título,
ou a partir do menu do ícone na área de notificação.

![A janela Opções](assets/options.png)

Todas as definições são **guardadas imediatamente** — não existe botão
«Aplicar».

## Geral

| Opção                                             | Efeito                                                                                                       |
| ------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| **Iniciar no arranque do Windows**                | Inicia automaticamente com a sua sessão do Windows.                                                          |
| **Minimizar para a bandeja do sistema**           | Minimiza a janela para a área de notificação (bandeja) em vez de a deixar na barra de tarefas.               |
| **Fechar minimiza para a bandeja do sistema**     | Fechar minimiza a janela para a área de notificação (bandeja) em vez de encerrar a aplicação.                |
| **Iniciar minimizado na bandeja do sistema**      | Inicia diretamente na bandeja, com a janela oculta.                                                          |

!!! info "Como fechar mesmo a aplicação se o fecho minimiza para a área de notificação?"
    Se **Fechar minimiza para a bandeja do sistema** estiver ativado, a cruz deixa de fechar a aplicação.<br>
    Use **Sair** no menu do ícone da área de notificação (clique com o botão direito).

## Aparência

### Tema da aplicação

*Sistema* (segue o estilo do Windows), *Claro* ou *Escuro*.<br>
O botão :material-weather-sunny:/:material-weather-night: da barra de título também alterna rapidamente o tema.

### Estilo da sequência

Escolhe a representação da [sequência](applications.md#a-linha-temporal):

- **Duplo** — Duas faixas independentes que apresentam cada sequência.
- **Mono** — Uma única faixa dividida ao meio, uma metade para cada sequência.

### Idioma da interface

Tradução completa para: francês, inglês, alemão, espanhol, italiano, português.<br>
Aplicado de imediato, sem necessidade de reiniciar, e guardado na configuração. <br>
Também disponível na barra de título, com a bandeira do idioma atual.<br>

!!! info
    Definido automaticamente conforme o idioma do Windows no primeiro arranque, mas pode ser alterado a qualquer momento.

## Atualizações

- **Verificar atualizações automaticamente** — ativa a verificação automática todos os dias.
- **Verificar agora** — inicia uma procura imediata. O resultado aparece sob a etiqueta (atualizado / nova versão disponível).

!!! info
    Quando há uma atualização disponível, aparece um **emblema** na barra de título; um clique inicia a transferência e a instalação.

## Depuração

### Nível de registo

Determina o detalhe escrito nos ficheiros de registo. A alteração aplica-se **imediatamente**, sem reiniciar a aplicação.

| Nível                     | Conteúdo                                                       | Quando usar                |
| ------------------------- | ---------------------------------------------------------------- | -------------------------- |
| **Erro** *(predefinição)* | Apenas erros e avisos.                                         | Em utilização normal.      |
| **Debug**                 | + o desenrolar das operações (deteções, arranques, paragens…). | A pedido do suporte        |
| **Trace**                 | + o detalhe dos valores internos. Muito pesado.                | A pedido do suporte.       |

É criado um novo ficheiro **todos os dias**, e os registos com mais de **7 dias** são eliminados automaticamente.

!!! tip
    Lembre-se de **repor o nível em Erro** assim que o seu problema estiver submetido: os níveis Debug e Trace são muito pesados.

### Exportar

Cria um ficheiro **`zip`** com todos os seus registos **e** a sua configuração, necessários para fins de suporte.

### Repor a aplicação

Apaga **todos os seus perfis e definições** e recomeça do zero, como numa instalação nova.<br>
**É pedida uma confirmação explícita.**

!!! danger "Ação irreversível"
    Nada é recuperável após uma reposição.<br>

## Acerca de

Mostra os detalhes da aplicação e as ligações rápidas para o **Discord**/**Flightsim.to**.
