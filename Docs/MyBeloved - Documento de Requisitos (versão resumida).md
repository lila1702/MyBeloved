# REQUISITOS FUNCIONAIS:
- [ ] O usuário deve poder se cadastrar utilizando o e-mail e a senha
- [ ] O usuário deve poder se cadastrar utilizando o login com Google ou Microsoft
- [ ] O usuário deve conseguir realizar o login utilizando o e-mail e a senha
- [ ] O usuário deve conseguir realizar o login utilizando a conta do Google/Microsoft
- [ ] O usuário deve conseguir redefinir a senha
- [ ] O usuário deve ser capaz de criar "cadernos"
- [ ] O usuário deve ser capaz de editar "cadernos"
- [ ] O usuário deve ser capaz de apagar "cadernos"
- [ ] O sistema deve salvar a "página" do usuário em cache local
- [ ] O usuário deve ser capaz de adicionar "categorias"
- [ ] O usuário deve ser capaz de editar "categorias"
- [ ] O usuário deve ser capaz de remover "categorias"
- [ ] O usuário deve poder criar uma "página"
- [ ] O usuário deve poder editar uma "página"
- [ ] O usuário deve poder excluir uma "página"
- [ ] O sistema deve permitir a criação de um link de sincronização com um "parceiro"
- [ ] O sistema deve permitir a opção de "término", onde os "cadernos" atuais serão congelados e desabilitados, e um novo link de sincronização gerado
- [ ] O sistema deve criar uma conta de visitante chamada "parceiro" quando o link de "sincronia" for compartilhado
- [ ] O sistema deve permitir que o "parceiro" visualize os "cadernos" finalizados
- [ ] O sistema deve permitir que o "parceiro" visualize as "páginas" do "caderno"
- [ ] O sistema deve pedir confirmação para a exclusão de "cadernos", "páginas" e "contas"
- [ ] O sistema deve notificar no e-mail do usuário que o "parceiro" aceitou/acessou seu "caderno"

# REQUISITOS NÃO FUNCIONAIS:
- [ ] O sistema deve rodar em navegadores de computador Chrome, Firefox e Edge
- [ ] O sistema deve rodar em navegadores de celular Chrome, Firefox, Samsung Internet e Safari
- [ ] O sistema deve possuir interface responsiva para ser visualizada em celulares e tablets
- [ ] O sistema deve ser feito em .NET 8.0
- [ ] A interface do sistema deve ser feito em HTML, CSS, TypeScript e Angular 18
- [ ] O sistema deve garantir a consistência de sua construção utilizando conteinerização com Docker
- [ ] O sistema deve estar de acordo com a LGPD
- [ ] O sistema deve estar de acordo com a WCAG 2.1

# REGRAS DE NEGÓCIO:
- [ ] O usuário não pode criar um caderno novo enquanto não tiver finalizado os que já foram criados
- [ ] Um caderno é considerado finalizado quando todas as categorias obrigatórias possuírem uma "página" ligada a ela, e o usuário marcar o caderno como finalizado para compartilhar com um "parceiro"
- [ ] Uma "categoria" só pode possuir uma "página" ligada a ela no mesmo "caderno" por vez
- [ ] Um "parceiro" só pode visualizar uma página por dia
- [ ] Um "caderno" só pode ser editado enquanto ainda não houver sido marcado como finalizado
- [ ] Só pode ser criado um link de compartilhamento por conta de usuário
- [ ] Ao excluir um "caderno", o link de "parceiro" deve permanecer existente
- [ ] Os "cadernos" devem ter no mínimo 52 categorias
[] O cache local deve permanecer até o usuário fazer logoff da sessão
