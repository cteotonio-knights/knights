# Use a imagem do Node.js
FROM node:20.12-alpine


# instala um servidor http simples para servir conteúdo estático
RUN npm install -g http-server

# Defina o diretório de trabalho no container
WORKDIR /app

# copia os arquivos 'package.json' e 'package-lock.json' (se disponível)
COPY package*.json ./

# Instale as dependências
RUN npm install

# Copie os arquivos do projeto para o diretório de trabalho no container
COPY . .

# Compile o projeto
RUN npm run build

# Expõe a porta 80
EXPOSE 80

# Comando para iniciar o servidor web
CMD ["http-server", "dist", "-p", "80"]

