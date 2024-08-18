# TelegramBotTest

предварительно нужно установить docker , docker compose

git clone https://github.com/bahtitm/TelegramBotTest.git

mkdir images

docker build . --file TelegramBotTest/src/TelegramBotTest/Dockerfile --tag telegrambottest

docker  save -o images/telegramBotTest.tar telegrambottest

./start
