Inputs:
1. Configuración de intervalo de presiones seguras (lo fijamos por contructor). [17, 21]
2. Presión (indirecto).
3. Estado de la alarma (activada o desactivada)

Output:
1. Texto del aviso por consola (indirecto).
2. Estado de la alarma (activada o desactivada).

Particiones:

P1: presion E (-inf, 16] => inseguro
P2: presion E [17, 21] => seguro
P3: presion E [22, inf) => inseguro

Fronteras:

--- 16 | 17 --- 21 | 22 ---

Ejemplos, rango [17, 21]

[x] (presion: 16, alarma: desactivada) => (alarma: activada, "alarma activada")
[x] (presion: 16, alarma: activada) => (alarma: activada, none)

[x] (presion: 17, alarma: desactivada) => (alarma: desactivada, none)
[x] (presion: 17, alarma: activada) => (alarma: desactivada, "alarma desactivada")

[x] (presion: 21, alarma: desactivada) => (alarma: desactivada, none)
[x] (presion: 21, alarma: activada) => (alarma: desactivada, "alarma desactivada")

[x] (presion: 22, alarma: desactivada) => (alarma: activada, "alarma activada")
[x] (presion: 22, alarma: activada) => (alarma: activada, none)
