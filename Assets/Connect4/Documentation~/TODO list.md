### Board
- Undo/Redo movements
- Refactor win conditions (extract entity)
  - Abstraction "tokensequence"
    - Consecutive 4 then win

### Match
- Abstraction with Board, Cursor, Players and Current turn
- Support for non-human players
  - Computer player needs board state/memento

### Drop a token use case
- How the current cursor column is stored?
- How is validated the current cursor column lets a drop?
- How is validated game is not over?
- What if drop leads to victory?
- Where is stored what player has the current turn?
- To async logic!!!

### Drop a token - error cases
- Risk: legal move assumed same as not-full column.
  - If control takes a try after game over, it will exxxxplode!