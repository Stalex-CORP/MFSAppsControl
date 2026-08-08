# Perfis

Um **perfil** agrupa um conjunto de aplicações com as suas definições.<br>
Crie vários conforme as suas utilizações (voo online IFR, VFR, A320, A380…) e alterne entre eles com um clique.

![Os perfis](assets/profiles.png)

!!! info "O perfil ativo é o que comanda a sequência"
    O perfil **apresentado** é o que o MFSAppsControl executa para a sequência.<br>
    O perfil em utilização quando o simulador é iniciado é indicado por um **:material-lock:{ style="color:#3ecf8e" }**.

## Criar um perfil

Clique no botão **:material-plus-circle-outline:** à direita dos separadores.<br>
É criado um novo perfil vazio e é-lhe pedido que o nomeie.

![Criar um perfil](assets/profiles-create.gif)

!!! note "Nome único e cancelamento"
    Dois perfis não podem ter o **mesmo nome**.<br>
    Enquanto o nome introduzido já estiver em uso, o campo fica <span style="color:red;">**vermelho**</span> e a validação fica bloqueada.<br>
    Para **cancelar**, clique na cruz **:material-close-circle:** ou prima **Esc**.

## Menu contextual

Está disponível um menu em cada emblema de perfil, através de **:material-dots-horizontal:** ou de um **clique com o botão direito**.
Este menu permite **mudar o nome**, **eliminar** ou **duplicar** o perfil.

![Menu contextual dos perfis](assets/profiles-menu.png)

### Duplicar um perfil

Para partir de um perfil existente sem ter de reconfigurar tudo.
É criada uma cópia, com **todas as suas aplicações e as respetivas definições**, chamada «*nome do perfil* (cópia)», que deve renomear com um nome único.

![Duplicar um perfil](assets/profiles-duplicate.gif)

### Mudar o nome de um perfil

Ao mudar o nome, este tem de ser **único** e bloqueará a validação enquanto não o for.

![Mudar o nome ou eliminar um perfil](assets/profiles-rename.gif)


### Eliminar um perfil

A eliminação de um perfil é **irreversível** e apaga **todas as aplicações e definições** que ele contém.<br>
Não é possível eliminar o último perfil disponível.

![Eliminar um perfil](assets/profiles-delete.gif)

### Reordenar

**Arraste e largue** os emblemas para mudar a sua ordem.
Isto é puramente visual, para o ajudar a encontrar mais facilmente os seus perfis preferidos.

![Reordenar os perfis](assets/profiles-reorder.gif)

## Bloqueio automático

Os perfis ficam **bloqueados** (aparece um :material-lock:{ style="color:#3ecf8e" } no perfil ativo) para evitar qualquer alteração durante a execução.
