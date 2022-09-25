### Board
- Undo/Redo movements
- Refactor win conditions (extract entity)
  - Abstraction "tokensequence"
    - Consecutive 4 then win
- La win condition tiene que devolver qué tokens forman la secuencia ganadora
- Imp: historial para poder hacer pop fácilmente y, además, para mirar desde fuera la última (row, col) puesta.
### Match
- Abstraction with Board, Cursor, Players and Current turn
- Support for non-human players
  - Computer player needs board state/memento

### Infraestructura, presentación
- Await properly whenever an input calls a controller!!!

### Drop a token - error cases
- Risk: legal move assumed same as not-full column.
  - If control takes a try after game over, it will exxxxplode!