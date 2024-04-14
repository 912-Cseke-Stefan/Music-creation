playableRepository interface:
- void add(Playable elem)
- void delete(int id) throws NotFoundError
- Playable? search(int id)
- Playable[] getAll() <- might suffer modifications

musictagRepository interface:
- void add(MusicTag elem)
- void delete(int id) throws NotFoundError
- MusicTag? search(int id)
- MusicTag[] getAll() <- might suffer modifications

Service interface:
- void add(Playable elem)
- void deletePlayable(int id)
- Playable? searchPlayable(int id)
- Playable[] getAllPlayable()
- void add(MusicTag elem)
- void deleteTag(int id) throws NotFoundError
- MusicTag? searchTag(int id)
- MusicTag[] getAllTags()
- Playable create(Playable[] elements)

*Playable* file format: .wav


#### Niste tutoriale pentru Git:
https://git-scm.com/book/en/v2/Git-Basics-Working-with-Remotes \
https://git-scm.com/book/en/v2/Git-Branching-Branches-in-a-Nutshell \
https://git-scm.com/book/en/v2/Git-Branching-Basic-Branching-and-Merging
