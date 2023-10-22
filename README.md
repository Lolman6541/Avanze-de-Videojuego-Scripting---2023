# Avanze-de-Videojuego-Scripting---2023
------------------------------------------- BETA / (Tercera entrega) ----------------------------------------------------------------
Integrantes: Juan Pablo Arango Zuleta y Abraham Peláez Trujillo

- Se hicieron modificaciones en el script del playercontroller agregando que el personaje se mantenga dentro de los limites del juego y implementamos la logica de cuando el "player" entre en contacto con el pick up de vida le sume correctamente una Vida.-

- Se añadio la Clase Planet que lo que hace es que El planeta puede moverse hacia abajo con una velocidad determinada (speed) y puede ser reposicionado en la parte superior de la pantalla para que vuelva a aparecer después de alcanzar la parte inferior.

- Se añadio la Clase PlanetController que controla la aparición y movimiento de los planetas en el juego. Reposiciona los planetas cuando llegan a la parte inferior de la pantalla y permite que vuelvan a aparecer desde arriba para mantener un ciclo continuo de aparición.

- Se añadio la Clase Star que controla el movimiento hacia arriba de una estrella en el juego. La estrella se desplaza verticalmente en la pantalla con una velocidad determinada (speed) y se reposiciona en la parte superior de la pantalla de forma aleatoria si ha pasado por la parte inferior. Este comportamiento proporciona la ilusión de un flujo constante de estrellas en el fondo del juego.

- Se añadio la Clase StarGenerator que genera estrellas. Las estrellas se instancian en posiciones y velocidades aleatorias dentro de la pantalla y cada una tiene un color distinto de un conjunto predefinido. Este script se ejecuta al inicio del juego para generar las estrellas.

- Se añadio la Clase AsteroidControll Que controla el movimiento del asteroide hacia abajo, verifica si colisiona con el jugador o una bala del jugador y crea una explosión en la posición del asteroide cuando es destruido. Es parte del comportamiento de los asteroides en el juego.

- Se añadio la Clase AsteroidSpawner que controla la generación de asteroides en el juego. Cada cierto tiempo, instancia un asteroide en una posición aleatoria en la parte superior de la pantalla y programa la generación del siguiente asteroide con un tiempo de espera que disminuye gradualmente, lo que aumenta la velocidad de generación.

- Se añadio la Clase PickupController que lo que hace es que controla un "Pickup" que se mueve hacia abajo a una velocidad constante. Cuando el Pickup sale de la vista de la cámara, se destruye. Además, cuando la nave del jugador colisiona con el Pickup, el objeto se destruye, lo que indica que el jugador ha recolectado el objeto.

- Se añadio la Clase PickupSpawner que genera Pickups (por ejemplo, "pick-ups" de vida) en la parte superior de la pantalla a intervalos regulares. Estos objetos se generan aleatoriamente en el eje X dentro de los límites de la cámara, y se repiten en función del valor de spawnInterval.

- Se añadio la Clase TimeCounter que simplemente nos sirve para contar y mostrar el tiempo transcurrido en el juego en minutos y segundos. 

- Se añadieron SFX y musica de fondo al juego.

- Se añadio la interfaz "IEnemy" proporciona un contrato que especifica qué operaciones deben ser implementadas por cualquier clase que quiera ser considerada como un enemigo (IEnemy) en el contexto del juego. Cada método define un comportamiento relacionado con el movimiento, la clonación, las colisiones y la reproducción de una explosión para los enemigos en el juego.

- Se implemento el patron de diseño "Singleton" para el GameManager.

- Se implemento el patron de diseño "Pooling" Para las balas del Player.

- Se implemento el patron de diseño "Factory" Para las naves enemigas.


Enlance del EXE.
El juego se llama "New Unity Project.exe"
https://drive.google.com/drive/folders/1hMrdDWH1J_DCEASrfIfkFM_-tKJM5bbq



------------------------- ALFA (Segunda Version) ----------------------------------------------------
# Avanze-de-Videojuego-Scripting---2023
Integrantes: Juan Pablo Arango Zuleta y Abraham Peláez Trujillo
No hay cambio respecto a la entrega anterior debio a que no habiamos hecho el codigo base, por lo tanto esta es el primer avanze respecto a codigo y clases agregadas:

•	Se agrego las siguientes clases: Destroyer.cs, EnemyBullets.cs, EnemyController.cs, EnemyGun.cs, EnemySpawner.cs, GameManager.cs, PlayerBullet.cs, PlayerController.cs
