# PHOTON SINCRONIZAR VARIABLES ENTRE JUGADORES

El script principal esta en el gameobject llamado ControlDePuntosEnRed donde se hace referencia a la interface y esta el photon view
![VariablesYTextos](https://github.com/kone9/PhotonEnviarVariablesEntreJugadores/blob/main/interfaceUnity.jpg)

![VariablesYTextosGIF](https://github.com/kone9/PhotonEnviarVariablesEntreJugadores/blob/main/photonSincronizarVariables.gif)


## Te recomiendo este curso
https://academy.zenva.com/product/multiplayer-game-development-mini-degree/
 
 Te recomiendo estos cursos.. Ni en platzy, ni en EDteam, ni en casi ningúna plataforma vi esta clase de cursos con photon. Están en ingles, pero podes usar subtítulos en ingles y si casas más o menos entendes. Yo vi la introducción donde enseñan a crear el servidor, conecciones, pantalla para conectar y movimiento básicos en red, etc.. Lo mejor de estos cursos es que tienen varias mécanicas resuletas con Photon a parte de enseñar a usar Microsoft Azure PlayFab para crear logging, score entre otras cosas que ncesita un juego profesional multiplayer en linea... En mi caso lo abandoné porque quiero dedicarme a Unreal Engine, pero si queres aprender photon estoy seguro de que estos cursos te van a servir para convertirte en una profesional con la herramienta.....


## explicacion básica

No soy muy tecnico, pero tengo expriencía y te explico desde mi conocimiento..Creo que Photon es la única herramienta actual seria para hacer juegos multiplayer con Unity, hay otras, pero nose si valgan la pena o sean estables.. Lo unico que para mi es mejor que photon es la herramienta multiplayer que Posee Unreal Engine, pasar variables entre jugadores es 2 nodos con unreal....A mi me costo 3 meses entender como enviar variables con photon.. Si tenes una interface y obviamente necesitas sincronizar una caracteristica.. "La interface es solo la tuya" y solamente envias la variable, entonces en cada jugador sincronizas la interface..Entendes?.. El secreto es enviar la variable.. "Este es el problema que nadie explica con photon en youtube".. Todos repiten el mismo tutorial de crear el lobby, conectarse y mover... Osea el problema es que tenes que ejecutar todo localmente.. Entendes?..La interface, los efectos, todo localmente.. Solo sincronizas posiciones y "variables" entre jugador y enemigo.. El tema de las variables es lo más importante y la cabeza tiene que hacerte click para que entiendas quien es el jugador y quien es el enemigo cuando usas photon.. Una ves que comprendes que todo lo ejecutas de forma local y que solo recibis variables ya esta. Entonces creas un script que se llame variables globales en red, y la ejecutas desde un lado y desde el otro... Sino pensaste desde un comienzo el proyecto como multiplayer te va a explotar la cabeza, pero tendrias que poder solucionarlo con el tema de enviar variables de la forma que te muestro en este proyecto.


## Entonces

"Si Quiero sincronizar el canvas y resulta que tengo que hacer o un Singleton o que cada cliente tenga una referencia al canvas, me deja mucho codigo feo"....
Justamente a eso me refiero, que cada cliente maneje su canvas y solo envia variables, no hagas referencia al canvas, solo usa variables.. "El singleton hacelo solo con las variables si es necesario"