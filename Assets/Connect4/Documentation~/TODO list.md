### Board
- Undo/Redo movements
- Refactor win conditions (extract entity)
  - Abstraction "tokensequence"
    - Consecutive 4 then win
- La win condition tiene que devolver qué tokens forman la secuencia ganadora
### Match
- Abstraction with Board, Cursor, Players and Current turn
- Support for non-human players
  - Computer player needs board state/memento

### Drop a token use case
- What if drop leads to victory?
- Where is stored what player has the current turn?
- To async logic!!!

### Drop a token - error cases
- Risk: legal move assumed same as not-full column.
  - If control takes a try after game over, it will exxxxplode!