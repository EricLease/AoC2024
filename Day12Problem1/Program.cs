﻿// Expect 1930
using Utilities;

const string _testInput =
    """
    RRRRIICCFF
    RRRRIICCCF
    VVRRRCCFFF
    VVRCCCJFFF
    VVVVCJJCFE
    VVIVCCJJEE
    VVIIICJJEE
    MIIIIIJJEE
    MIIISIJEEE
    MMMISSJEEE
    """;

// Solution: 1421958
const string _puzzleInput =
    """
    VVVVVVVVVVVCCCCLLLLLLLLLLLLLLLLLSSSSFFFFFFFFFFFFHHHHHHHHHHHHLLLLLLLLLLLLMLPPPPPPPZZZZZGGGGGGNNNXXXXXXXFFFLLFVVCCCDDCCCYYYYYYYYYYYYYYYYYYCCCC
    VVVVVVVVVVCCCCCCCCDLLLLLLLLLLLLSSSSFFFFFFFFFFFFFHHHHHHHHHHHHHLLLLLLLLLLLMLLLPPPPPZZZZZZGGGGGGNXXNNNXXFFFFFFFVVCCCCCCCCYCCYYYYYYYYYYYYYYYCCCC
    VVVVVVVVCCCCCCCCDDDDLLLLLLLLLLLLSSSSFFFFFFFFFFFFHHHHHHHHHHHHHLLLLLLLLLLLLLLPPPPZZZZZZZZGGGGGNNNNNNNXFFFFFFFFFVCCCCCCCCCCCCYYYYYYYYYYYYYYYYCC
    VVVVVVVVCCCCCCDDDDDDLLLLLLLLLLLLSSSFFFFFFFFFFFHHHHHHHHHHHHHHLLLLLLLLLLLLLLLPPPPZPZLZLLLLLLGNNNNNNNNNFFFFFFFFFVVCCCCCCCCCCCCYYYYYYYYYYYYYYYCC
    VVVVVVVVCCPCDDDDDDDDDDLLLLLLLLLLSSSSSFFFFFFFFFHHHHHHHHHHHHHHLLLLLLLLLLLLNLLPPPPPPLLLLLLLLLGNNNNNNNNFFFFFFFFFFCCCCCCCCCCCCCCYYYYYYYYYYYYCCCCC
    VIVZVVVPPPPPDDDDDDDDDDDDLLLLLLLLSSSSSSFFFFFFFFFHHHHHHHHHHHHHHLLLLLLLLLLLLLLPPPPPLLLLLLLLLLLNNNNNNNNNFFFFFFFFFCCCCCCCCCCCCCYYYYYYYYYYYYYCCCCC
    VIIZZVVVVPPUUUDDDDDDDDFLLLLLLLLSSSSSSSFFFFFFFFWHHHHHHHHHHHHHHHLLLLELLLLBPPPPPPPPLLLLLLLLLLLLNNNNNNFFFFFFFFFFFCCCCCCCCCCCCCGYYYYYYYYYYYYYCCCC
    IIIZZZZZIIUUUUDDDDDDDDFLLLLLLLLISSSSSSFFFFFFFKQQHHHHHHHHHHHHHHLLELELLLLLPPPPPPPPLLLLLLLLLLLNNNNNNNNFFFFFFFFFFCCCCCCCCCCCCCCYYYYYYYYYYYYCCCCC
    IIZZIZIIIIUUDDDDDDDDPPLLLLLLLLZIIISSSSFIIFFFFFQQHHHHHKKPHHHHHHLLEEELLLEPPPPPPPPPAALLLLLLLLLNNNNNNNNFFFFFFFFFFFFCCCCCCCCCCCCCYYYYYYYCCCYCCCCC
    IIIIIIIIIIIUUDDDDDDDDPPPPPLPPLLIIEIIIIIIIIFFFFQQHHHHHKKPHHHHHEEEEEEEEEEPPPPPVVVVLLLLLLLLLLNNNNNNNNFFFWFFFFFFFFCCCCCCCCCCCCLLYYYLYLYCCCYCCCCC
    IIIIIIIIIIIUUUUDKKIIIIIIPPPPPLLIIIIIIIIIIIFFQQQQQHHHKKKPPPHHHHENNNEEEEQQPQQQVVVLLLLLLLLLLLLNNNNNNNNNFFFFFFFQQFCCCCCCCCCCLLLLLLLLLLLCCCCCCCCC
    IIIIIIIIIIUUUUUIIKIIIIIIPPPPLLIIIIIIIIIIPPHFFQQQHHHHKKKKKPPPPCENNCEEEEQQQQQQQQVLLLLLLLLLLLNNNNNNNNNNFFFFFFFFQQQCCCMMCCCSLLLLLLLLLLLLCCCCCCCC
    IIIIIIIIIUUUUUUIIIIIIIIIIPPPLLLLIIIIIIIPPPHFFFQQHHHHKKKPPPPCCCCNCCEQQQQQQQEQQQQLLLLLLLLLLLNNNNNNNNNNWWWFFFQQQNQCMMMMMMMLLLLLLLLLLLLLLCCCCCCC
    IIIIIIIIIIIIUUUIIIIIIIIIPPPPPPLIIIIIIIIPHHHHHHHHHHHHHHKPPPPPPCCCCCQQQQQQQQQQQQLLYYLLLLLFLLNNNNNNIINNWWWFFQQQNNNMMMMMMMMLLLLLLLLLLLLLLCCCCCCC
    IIIIIIKKKIIIIUUUIIIIIIIIPPPPPPLIIIIIIIIPHHHHHHHHHHFFHHHFPPPPCCCCCCCQQQQQQQQQQQLLYYLLLLLFLBNNNNNNIIZNWWWWFFFNNNNNNNMMMLLLLLLLLLLLLLLLLGCCCCCC
    IIIIKKKKKKKGGKIIIIIIIIIIIIPPPPPIIIIIIPPPLHHLLLHHHHFFFFFFFPFCCCCCCCCQQQQQQQQQQQTTTTTTTLTFNNNNNNNNIINNNWWWNNNNNNNNMMMMMMLLLLLLLLLLLLLLLGGCCCCC
    IIIIIIKKKKIKKKKIIIIIIIIIIIPPPPPPIPPPLLLLLLLLLLLHHHFFFFFFFFFSSCCCCCCCQQQQQQQQQTTTTTTTTTTFFNNNNNNNNIIDMDDDNNNNNNNNNNNMMMMMMLLLLLLLLLLLCGGGCCCC
    IIIIKKKKKKKKKKKIIIIIIIILIIPPPPPPPPPLLGLLLLLLLLLLLVFFFFFFFFFFCCCCCCCCCCQQQQQQQTTTTTTTTTTFFFNYYNNNNNDDDDDDNNNNNNNNNNMMMMMMMLLLLLLLLLLLGGGGCCCC
    IIIKKKKKKKKKKWIIIIIIIILLLLPPPLPPPPPLLLLLLLLLLLLLLLFFFFFFFFFFFCCCCCCCCCQQQTTQTTTTTTTTTDDDDFNYYYYNNDDDDDDDLNNNNNNNNNNMMMVLLLLLLLLLLLLLCCCCCCCC
    IIIIKKKKKKKKMWPWWWIIIIILLLLLPLLPPPPPPLLLLLLLLLLCCCCFFFFFFFFFCCCCCCCCCCCQQTTTTTTTTTTTTDDDDDDDYDNNDDDDDDDDDNNNNNNNENNMMMVVLVVVVLLLLLLLLCCCCCCC
    IIIIKKKKKKKWMWWWWIIIIILLLLLLLLLLPPPPLLLLLLLLTTTCFFFFFFFFFFFFFCCCCCCCCCCQQTTTTTTTTTTTTDDDDDDDDDNNDDDDDDDDDNNNNENNNNZMMMVVVVVVLLLLSSSSLCCCCCCC
    IIIIIKKWKWWWWWWWWWIIIIILELLLLLLLLPPPLLLLLLLLNTTTTFFFFFFFFFFFCCCCCCSEEEEQXTTTTTTTTTTTDDDDDDDDDDDDDDDDDDDDZNZZZZZZNZZZZMVVVVVVLLLLSSSSCCCCCCCC
    IIIIIGKWWWWWWWWWWWIIIIILELLLLLLLPPPPLLLLLLLLTTTVFFFFFFFFFJJJJCCCCSSSEESXXXTTTTTTTTTTDDDDDDDDDDDDDDDDDDDDZZZZZZZZZZZZZZZZVVVVVVLLLSSSCCCCCCCC
    IIIIIGWWWWWWWWWWWWIIIIIILLLLLLLLLPPPLLLLLLLLTTTTJJFFFFFFFJJJKTTCCCSSSSSSXSTTTTTVTTVVVDDDDDDDDDDDDDDDDDZZZZZZZZZZZZZZZZZZZVVVVVSSSSSCCCCCCCCC
    IIIIIGWWWWWWWWWWWWIIIIILLLLLLLFOOFPPPFLLLLLLTTTTTJFFFSFFFFJKKKKCCCSSSSSSSSSTTTTVVVVVNDDDDDDDDNDDDDDDDDDDZZZZZZZZZZZZZZZZVVVVVVSSSSSCCCCCCHCC
    IIIGGGGGWWWWWWWWIIIIIILLLLLLLLFFFFPFFFLLLLLLLTTTJJJFFFFFFJJJKKKLLLSSSSSSSSSTTTBVBBBBNDDDDDDDHNNNNDDDDDDDZZZZZZZZZZZZZZZZVVVVVVSSSSSCCNCCCCCC
    IIIGGGGGGGGWWGGIIIIIILLLLLLLLLFFFFFFFFFLLLLQQQQJJJJTLFFFFFFJJKKFSSSSSSSSSSSXBBBBBBNNNNDDNDNDDANNNDNDNNDDZZZZZZZZZZZZZZZZVVVVVVSSNSSCCCCCCCCC
    UUGGGGGGGGGGGGGGGIIIIILLLLLLLLFFFFFFFFFFQQQQQQQTJTTTTTFFFFJJFFFFJSSSSSSSSSSXBBBBBBBNNNNNNNNNDNNNNNNNNDDDDDZZZZZZPZZAZZAGGGVVVNNNNNSCCCCCCCCC
    UUUGGGGGGGGGGGGGGGIIILLLFLLLLLFFFFEEEEEEEEEEQQQTTTTTTTTTTFJJJFFFFFFSSSSSSSSXXBBBBBNNNNNNNNNNNNNNNNNDDDDDDZZZZZZZPAZAAAAAGGVVGNNNNNCCCCCCCCCC
    UUUUUGGGGGGGGGGGGIIIIILLFFFLFFFFFFEEEEEEEEEEQQXTTTTTTTTTTJJJFFFFFFSSSSSSSSSXXBBBBBNNNNNNNNNNNNNNNNNDDDDDDDZZZZTZAAAAAAAAAGGGGNNNNNCCCCCCCCCC
    UUUUUGGGGGGGGGGGVFFFFFFFFFFFFLLLLLEEEEEEEEEEQQQTTTTTTTTTTTFFFFFFFFSSSSSSSSSAAABBBBCNNNNNNNNNNNNNNFDDDDDDDDDZZZZUAAAAAAAAAGGGNNNNNNNCCCCCCCCC
    UOOOUGGGGGGGGGHHVFFFFFFFFFFFFLLLLLEEEEEEEEEEQQQTTTTTTTTNTIIIFFFFFFSFFSSSTSSAAARBBBNNNNNNNNNNFFFFFFZDDDDDDDDDDZUUAAAAAAAAAGGGGNNNNNNNNCCNCCNN
    OOODOGGGGGGGGGHHHFFFFFFFFFFFFLLLLLEEEEEEEEEEQQQQTTTTTTTTTTIIITFFFFXFFSSSTSAAAABBABANANNNNNNNFFFFFFZFDDDDDDDDRRUUUAAAAAAAAGGGGGNNNNNNNCCCCCCN
    OOOOOBGGGGGGGGGHFFFFFFFFFFFQFLLLLLLLEEEEEEEEQQQQTTTTTTTTTTTITTQFFRXSSSSSSSAAAAAAAAANAAAZNHHNFFFFFFFFDDDDDRRRRRUUUREAAAAAAGGGGNNNNNNNNNNCCCNN
    OOOOOOOGGGGGGGGGGFFFFFFFFFFLLLLLLLLLLEEEEEEEQQQQTTTWTTTTTPTTTTQQFXXXXXXSXAAAAAAAAAAAAAAAFFFFFFFFFFFCDDDDDRRRRRRRRRRAAAAAAAGGNNNNNNNNNNNNCCNN
    OOOOOOUGGGTGGGGGGFFFFFFFFYFLLLLLLLLLLEEEEEEEQQQQTTTWTTTTTPTTTTTTXXXXXXXXXHZAAAAAAAAAAAAFFFFFFFFFFFFCDDDRRRRRRRRREEEAAAAAAGGGGGNNNNNNNNNNNNNN
    OOOOOUUUGGUUGGGGGFFFFFFFFYYLLLLLLLLLLEEEEEEEQQQQQTWWTTTTTTTTTCCTZTXXXXXXXXZAAAAAAAAAAAAVVFFFFFFFFFFCCDORRRRORRRRRRRAAAAAGGGEEEEENNNNNNNNNNNN
    OOOOOGUUUUUUUGGGDFFFFFFFYYYLLLLLLLLLLQQQQQQQQQQQWWWFTLTTTTTTTCCTTTXXXXXXXZZZAAAAAAAAAVAVVFFFFAAAAFFFCCRRRRRRRRRRRRRAAAAAAGFEEEEEEWENNNNNNNNN
    OOOOGGGUUUUUUUUGFFFFFFFFFYYYLLLLLLLGGQNNQQQQQQQQWWWWLLTLLTTTTCTTGGXXXXXXZZZZZAAAAAAAAVAVVFFFFAAAAFFFFFRRRRRRRRRRRJJAJAAAAFFOEEEEEEEEENNNNNNN
    OGGGGGGGGUUUUUUUUFFFKFYYYYYYLLLLLLLGGQQNNQQQQQQWWWWWWLLLLLTTTTTTTTTTXXMXZZZZZZAAZAAAAVVVVVFFFAAAAFFFFFRRRRRRRRRRRJJJJJJEZZFFFFEEEEEEENNNNNNN
    GGGGGGGGGUUUUUUUUFFFKFFEEYYYLLLLLLLGQQNNNQQQQQWWWWWWWWLLLLTTTTTTTTTTWXXXZZZZZZZZZZAAVVVVVFFFFAAAAFFFFFNRRRROORJRRJJJJEEEFFFFFFEEEEEEENNNNGNN
    GGGGGGGGGUUUUUUUUFUUEEEEEYYYGGGGGGGGGGGGNQNNNWWWWWWWWWWLLLLLTTTTTTTTTXZZZZZZZZZZZZZVVVVVVVAAAAAAAAAAAAANRRRRRJJRRJJJJJEEEEEEEEEEEEEEENNNGGGN
    GGGGGGGUUUUUUUUUUUUUUEEEEEYGGGGGGGGGGGGNNNNNWWWWWWWWBBWLLLLLTTTTTTTTBBBZZBZZZZZZZZZVVVVVVVAAAAAAAAAAAAAURRRRJJJRRJJJJJLLEEEEEEEEFFEEEENGGGGN
    GGGGGGGGUUUUUUUUUUUUUUYYYYYYYGXGGGGGGGGNNNNNNNWWWWWWBBBLTTTTTTTTTTTTBBBBBBZZZZZZZNVSVVVVVAAAAAAAAAAAAAAUURRJJJJRDDJJLLLLEEEEEEEFLFFJJENGGGGG
    GGGGGGGGGUEUUEUUEUUUUUUYYYNYGGXGGGGGGGGGGNNMNWWWWWWWWBLLTBBTTTTTTTTTBBBBBBZZZZZZZNVVVVVVWAAAAAAAAAAAAAAUUJJJDDDDDDJJJJLLLEEEEFFFFFJJJJNGGGGG
    GGGGGGGEEEEEEEEEEEUUUYUYYNNYGGGGGGGGGGGGNNNMMWWWWWWNWBBBBBBBBBTTTTTTBBBBBZZZZZZZXNNVVVVVVAAAAAAAAAAAAAAUUDDDDDDDDDDJJJLLLLLEEEFFFFFJJJNJJGGG
    GGGGGFFEEEEEEEEEFFUUUYYYYNNNFFGGGGGGGGGNNNNMMMWWWAWBBBBBBBBBBBBTTBBBBBBBBZZZZZZZXXXSVVVEEFAAAAAAAAAAAAAUUYDDDDDDDDDDDLLLLLLEELFFFFJJJJJJJGAG
    BBPPGFFEEEEEEEEEFFUYYYYYYNNNNNGGGGGNNNNNNNNMMMMMMBBBBBBBBBBBBBBBBBBBBBBBHHHHZZZXXXXXXPZZZFAAAAAAAAAAAAAUUUDDDDDDDDDDDLLLLLLLLLTFFFFJJPJJJPPU
    BBGGGFFEEEEEEEEEFHHYYYYYYNNNNNNGGNNNNNNNNNMMMMMMMMBBBBBBBBBBBBBBBBBBBBBBHHHHZXXXXXXZXPZZZZAAAAAAAAAAAAAUUUDDDDDDDDDLLLLLLLLLJFFFFJJJPPPPJPPP
    BBBGBBEEEEEEEEEFFHHHYYYYYNNNNNZZGNNNNNNNNNMMMMMMMMMBBBBBBBBGGGGGGBBBBBBBHHHXXXXXXXXXXZZZZZZZZAAAAAAAAAAUUUDDDDDDDDDDDLLLLLLQQQQQQQQJPPPPPPPP
    BBBBBBEEEEEEEEEEHHHHYYYYYNNNNNNNNNNNNNNNNNIMMMMMMMMBBBBBBBBZZGGGGBBBBBBGHHHHHXXXXXXXXZZZZZZZZAAAAAAAAAAUUUIDDDDDDDDDOLLLJLLQQQQQQQQJJPPPPPPP
    BBBBBBEEEEEEETEEHHHHHYYYNNNNNNNNNNNINNIIIIIMMMMMMMMBBBBBBBBZGGGGGGGGGGGGHHHHCXXXXXXXXXZZZZZZZZAAAAAAUUUUUUDDDDDDDDDDLQQQQQQQQQQQQQQJPPPPPPPP
    BBBBBBBEEEEFHHHHHHHHHYYYYYNNNNNNNNIINIIIIIIIMMMMMMMMBBBBBBBBBGGGGGGGGGGGGHHHXXXXXXXXXXZZZZZZZZZZHUUUUUUUUUDDDDDDDDDDDQQQQQQQQQQQQQQPPPPPPPPP
    BBBBBBBBFFEFHHHHHHHHHHYYYYYYNNNNNNNIIIIIIIIIMMMMMMMMMBBBBBBBBGGGGGGGGGGWWHHMXXXXXXXXXXXZZZZZZZZZZZVVVVUUDDDDGDDDWWDVVQQQQQQQBBJJJPPPPPPPPPPP
    BBBBBBBBFFFFHHHHHHHHHYYYYYNNNNNNNNNUUIIIIIIMMMMMMMMMMBBBBBBBBCGGGGGGGGGMMMHMXXXXXXXXXXZZZZZZZZZZZZVVNNNUDDSDDDDDDWDYYQQQQQQQBJJJPPPPPPPPPPPP
    BBBBBBBFFFFFFHHHHHHHDYYYYYYYNYUUNNIIIIIIIIMMMMMMMMMMMMBBBBBBPBGGGGGGGGXMMMMMXXXXXXXXXXXZZZZZZZZZZZVVNNNUADSDDDDDDDQQQQQQQQQQBJJJPPPPPPPPPPPP
    BBBBBBBFFFFFFHHHHHHHHYYYYYYYYYYUNNNIIIIIIIMMMMMMTMGGGGBBBBBBBBGGGGGGGGXXMMMMXXXXXXXXXXXZZZZZZZZZZZVVNNNANNNNDDDQYYQQQQQQQQQQBBPPPPPPPPPPPPPP
    BBBBBBBFFFFFFFFHHHHHHHHYYYYEYUUUUNIIIIIIIIIMMMTMTMGGEEBBBBBBBBGGGGGGGXXXXMMMMXXXXXXXZZXXZZZZKZKKZZZZNNNNNNNNNDDDWYQQQQBBBBBBBBBBPDBBCPPPPPPP
    NNFWBBFFFFFFFFFFHHHHHCCYYYYVUUUUIIIIIIIIIIIIIITTTTGITERRRBBBGGGGGGGGGGGGMMMMMMMMXXXXXZXZZZZZKKKKKZZNNNNNNNNNNNNRWWQQQQYBBBBBBBBBBBBCCCCPPPPP
    FFFFFFFFFFFFFFFFHHHHHCCQQQQVVUUUIIIIIIIIIIIIIIITTTGTTTRRRBBBRRRRGGGGGRRGPMMMMMMXXPXZZZZZZZZKKKKKKZNNNNNNNNNNNNNNWWWYYYBBBBBBBBBBBBBCCCCPPPPP
    FYFFFFFFFFFFFFFFFBHHCCCCQQVVUUUAIIIIIIICCCCCCCCTTTTTTTTRRRRRRRRGGRRRRRRGMMMMPPPPPPPPPRRKKKKKKKKKKKKNNNNNNNNNNNNNWWWWYYYBBBBBBBBBBBBCCPPPPPPP
    DYFFFFFFFFFFFFFFFCCCCCCCQVVVVUUAAAAIAIICCCCCCCCTTTTTTTTTRRRRRRRRRRRRRRMMMMMMPPPPPPPPPRRAKKKKKKKKKKKSNNNNNNNNNNWWWWWYYYYBEBBBBBBBBBCCCPPPPPPP
    DYFDDFFFFFFFFFFCCCCCCCCCVVVVVVVAAAAAAAACCCCCCCCTTTTTTTTTRRRRRRRRRRRRRRRRMJJJPPPPPPPPPRRKKKKKKKKKKKKSNNNNNNNNNWWWWWWWWEEEEBBBBBBBBBBBPPPPPPPP
    YYYYFFFFFFFFFFCCCCCCCCCMMVVVVCWWAAAAAAACCCCCCCCTTTTTTTTTRRRRRRRRRRRGGRRGJJJJPPPPPPPPPRRKKKKKKKKKKKSSSNNNINNNWWWWWWWWWWWWEBBBBBBEEQBPPPPIIIIP
    YYYYFFFFFFFFWWCCCCCCCCVVVVVWSWWWAAAAAAACCCCCCCCTTTTTTTTTRRRRRRRRRRRGGGGGJEJJEEPPPPPPPUAKKKKKKKKKKKSSSNIIIINNNNWWWWWWWWEEEBBBBBEEEQQPPPPIIIII
    YYYYFYFFFJFMWWWCWWCCCCVVVVVWWWWWAAAAAAAAAQQQQQTTTTTTTTTTTRRRRRRRGGGGGGGGEEEEEEPPPPPPPUUFFKKKKKKKKKSSSNSIIIINNNNNWWWWWBBBEBBBBEEEZQZLPPPPIIII
    YYYYYYFFYJJWWWWWWCCCCCCVVJWWWWWWWWAAAAAAAQQQQTTTTTTTTTTTTRRRRRRRGGGGGGGGGEEEEEPPPPPPPUUUUKKKKKKKKKSSSSSIINNNNNNNNWWWEBBBEBBBEEEEZZZZZZZZIIII
    YYYYYYYYYWWWWWWWWCCCCCCCJJJWWWWWWWAAAAAAAAQQQQTTTTTTTTTJTRRRRFFRGGGGGGGGGGGEEEPPPPPPPUUUUHHHHKKKSSSSIIIIIIINNAAAAWWWEBBBEEEEEEEZZZZZZZZZIIII
    YYYYYYYYYYWWWWJWWCCCCCCCCWWWWWWWWWWWAAAAAQQQQQTTTTTTTTTJJJRRRRFRRGGGGGGGGGGGEEPPPPPPUUUUUHSSSSSSSSSSSIIIIIIINAAAZWWWEBBBBBBBLEEZZZZZZZZZIIIZ
    YYYYYYYYYWWWWWWWWCCCCCCVVOWWWWWWWWWWWAAAAADDDQTTTTTTTTTJJJRRFFFFFIFGGGGGGGGGGUPPPPPPUUUUUHSSSSSSSSSSIIIIIIIIAAAAZIIEEBBBBBBBLLLZZZZZZZZZZZZZ
    YYYYYYYYYYWWWWWWHHHCCCVVOOWWWWWWQQQQQQAQQQDDDDTTTQTTTTJJJJJJFFFFFFFGGGGGGGGGUUPPPPPPUUUUYHSSSSSSSSSSIIIIIIIAAAAAIIIEEBBBBBBBLLLZNNRZZZZZZZZZ
    YYZZYYYYYYYFWWWHHHCCCCVVVVHWQWWWQUQQQQQQDDDDDDDTTQTTTTJJJJJFFFFFFIVVVVGGGGGGUUUUUUUUUUUUUUSSSSSSSZIIIIIIIIAAAAAAIIIIIBBBBBBBLLLNNNNGZZZZZZZZ
    YZZZZZYYFYYFFFHHHHCCCCTVVVVQQWPWUUUQUUDDPDDDDDAAAQQQQTTTFJFFFFFFFVVVYVGVGGGGGGUUUUUUUUUUUUUHHZZZZZZIIIIIIIAAAAAIIIIIEBBBBBBBLNNNNNNGGZZZZZZZ
    ZZZZZFFYFFFFFFHHZHCCHHTUVVQQQQUUUUUUUUDDDDDDDDAAAQAAQTTFFFFFFFFFFFVVVVVVVVGGGXUUUUUUUUUUUUCCHZZZZZZZZZZIIIIIAAIIIIIIEBBBBBBBLNNNNNNGGZZZZZZZ
    ZZZZZFFYFFFFZZZHZHHHHHTTVTTQQUUUUUUVVVDDDDDDDDDAUAAAAVELFEFFFFFFFFFVVVVVVVWVVVNUUUUUUUUUUUCZZPZZZZZZZZIIIIIIIIIIIIZIILLLLLLLLLNNNNGGGZZZZZZZ
    ZZZZCCFFFFFFZZZZZHHHHHTTTTTTQQUUUUUUUVDDDDDDDAAAAAAAVVELEEEFFFFFFFVVVVVVVLVVVVNNNUUUUUUUUNZZZZZZZZZZDIIZIIIIIIIIZIZIINLLLLLLLNNNNNOGZZZZZZZZ
    ZZZCCZFFFFFZZZZZZZHHTTTTTTQQQQQUUUUVVVVDDDDDDAAAAAAAAEEEEEEFFFVVVVVVVVVVVVVVVNNNNUNNUUUUNNNZZZZZZZZDDDDZZIIIIIIIZZZZNNNHHHLLLHHNNNOZZZZZZZZZ
    ZZZCZZZFFZFZZZZZZZZZTTTTTUQQQQUUUUUVVVVDDDDDDVVVAAAAEEEEEEEFFFFVVVVVVVVVVVVVNNNNNNNUUUNNNZNNZZZZZZZZZZZZZIIIIIZZZZZZHHHHHHLLHHPHNNOZZZZZZZZZ
    ZZZCZZZZZZZZZZZZZZZITTTUUUUQQQQUQQNVVVVDDDDDVVVVAAAAEEEEEEFFFFFVVVVVVVVVVVVVVNNNNNNUUNNNNZZZZZZZZZZZZZZZZIIIIIIZZZZZZHKHHHHHHHHHHZZVVZZZZZZZ
    CCCCCZZZZZZZZZZZZZYTTUUUUUUUQQQQQNNVVVVDDDDDVVVVAAAEEEEEEEEFFFFFAVJVVVVVVVVVVNNZZNNNNNNZZZZZZZZZZZZXZZZZZIIIIIZZZZZZZZHHHHHHHHHHHZZZZZZZZZZZ
    CCCCCZZZZZZZZZZZZYYYUUUUUUUUUZZZZZZZZZZDDVVDVVVVVVUUEEEEEEEEFFFFVVJVVVVVVVVVVVNZZZAAANNNNZZZZZZZZZZZZZZZZZZIIIZZZZZZZHHHHHHHHHHHHFZZZZZZZZZZ
    CCCCCZZZZZZZZZZZZYYYUUUUUUZUOZZZZZZZZZZVVVVVVVVPPPUUEEEEEEEBFFFWWVWWVPPNVVVVNNNZZAAAAAANNZZZZZZZZZZZZZZZZZZZIIZZZZZZZHHHHHHHHHHHZZZZZZZZZZJZ
    CCCCCCZZZZZZZZZZZZYYUUUUUUZZZZZZZZZZZZZNVVVVVVVPPPPPPEEEEEEWWWWWWWWWVPNNNNNNNNNZZAAAAANNZZZZZZZZZZZZZZZZZZZZFFFZZZZZDHHHHHHHHHHHZZZZZZZZZZZZ
    CCCCCCCZZZZZZZZZZZYYUUUUUUZZZZZZZZZZZZZNNVVVVPPPPPPPEEEEEEEWWWWWWWWWWNZNNNNZZNZZZAAAAANZZZZZZZZZZZZZZZZZZZZZZFFFZZZZLHHHHHHHHHHGGGGGGGGGZZYY
    CCCCCCCZZZZZZZZZYYYUUUUUUUZUZZZZZZZZZZZZNVVVVVPPPPPPPEEEEEEEENWWWWWWWNNNNNNZZZZZZAAAAAZZZZZZZZZZZZPPZZZZZZZZZZFFXXLLLOHHHHHHHYYGGGGGGGGGYZYY
    CCCCCCCZZZZZZZZZZZZUUUUUUUUUMMZZNNNZZZZZNNVVVVVVPPPPPPEEEEEERWWWWWWWNNNNNZZZZZZZZAAAAAAZAZZZZZKPZPPPPZZZZZZZZZFFXXXLLHPHHHHZHYZGGGGGGGGGYYYY
    CCCCCCZZZZZZZZZCCUUUUUUUUUUUMMMNNNNZZZZZNNNVVVVVVWSSSPPEEEEERWWWWWWNNNBNZGZZZZZZZZAAAAAAAAAJJPPPPPPPPPZZZZZZZZFFFLLLLHHHHHHLLYYGGGGGGGGGYYYY
    CCCCDDGGGZZZZZZCCUUUUWUUUUUUMMNNNNNZZZZRRRRRRRRRRRRSSPPPPPEFWWWWWWWWWWZZZZZZZZZZZZZZAAAAAAAARPRIPPPPPPZPRRRFFFFFFLLLLHHHLGGGGGGGGGGGGGGGYDYY
    CDCCDDGGGGGZZCCCCUUUUWUUUUUUMNNNNNNZZZZRRRRRRRRRRRRSSSPPPPPWWWWWWWWWWZZZZZZZZZZZZZZZZAAAAAJRRRRRPPPPPPPPPPRRFFRFFLLLLLHLLGGGGGGGGGGGGGGGDDYY
    CDDDDDGGGGGGTTTCCCCCUUZUUUUGGGJNNNNZZZZRRRRRRRRRRRRSSSSPPPPWWWWWWWWWWZZZZZZZZZZZZZZZZZZAJJJJJRRRPPPPPPPPPPPRRRRRFLLLLLLLLGGGGGGGGGGGGGGGDDYY
    DDDDDDDDDGGGGTTCCCGGZZZGUOUGGGNNNNNZZZZZNNRRRRRRRRRSPPPPPPPPWWWWWWWWWWWWZZZZZZZZZZZZZZZJJJJJRRRRPPPPPRRRPPPRRRRRRLLLLLLLLGGGGGGGGGGGGGGGYYYY
    DDDDDDDDDGGGTTTCCCGGGZZGUGGGGGGNNNNZZZZZNORRRRRRRRRPPPPPPPPPWWWWWWWWWGWWZZZZZZZZZZZZZZZZJJJJRRRRRPPPPRRRPPRRRRRLLLLLLLLWLLLTTLLGGGGGGGGGDDDD
    DDDDDDDDDGGTTTTTTTRRGGGGGGGGGGGNGNONOOONOORRRRRRRRRQPQPPPPPWWWWWWWWWWGGZGGGGZZZZZZZZZZZJJJJJRRRRRRPPRRRRPKRRRRRLLLLLLLLWLLLTTDDGGGGGGGGGDDDD
    DDDDDDDDDDGTTTTTTGGGGGGGGGGGGGGGGOOOOOOOOORRRRRRRRRQQQPQPPWWWWWWWWWWGGGGGGGGZZZZMZZZZJJJJJJJRRRRRRRRRRRRKKKRRRRRRLLLLLLLLLLLLEDDDDDDDDDDDDDD
    DDDDDDDDDDGTTTTTTOTTGGGGGGGGGGGGGOOOOORRRRRRRRRRRRRQQQPQQPPWWWWWWWWWWGGGGGGGZZZMMMMMZZJJJJJRRRRRRRRRRRRRRZKKRRVVVVLLLIILLLLLEEELDDDDDDDDDDDD
    DDDDDDDDDDTTTTTTTTTTGGGGGGGGGGGGOOOOOORRRRRRPJPQQQQQQQQQQPPWWWFGGWWGGGGGGGGGGZZZMMMMMJJJJJJRRRRRRRRRRRRRRRMKRRVVVVVVVIILLLMLLLLLDDDDDDDDDDDG
    DDDDDDDDDDTTTTTTTTTGGGGGGGGGGGGGOONNOORRRRRRCCKQQQQQQQQQPPPWWWFFGGJGGGGGGGGGGZZMMMMJJJJJJJJRRRRRRRRRRKRCKKKKKRVVVVVVVVILLDLLLLLLLLDDDDDMDDDG
    DDDDDDDDDTTTTTTTTGGGGGGGGGGGGGRRRRRRRRRRRRRRCCKKQQQQQQQQQPPWWWGGGGGGGGGGGGGGMMMMMMJJJJJJJJJJJRRRRRRRRKKCKKKKKKKVVVVVVFLLLDLLLLLLMMDDDDDMMMGG
    RRDDDDDDDTTTTTTTTCGGGGGGGGGGGGRRRRRRRRRRRRRRCCCQQQQQQQQQWWWWWWQGGGGGGGGGGGMMMMMMMMJJJJJJJJJJJRRRRRRRKKKKKKKKKKKKKVVVVVVLLLLLLLLMMMMMMDDMMMMG
    RRRDDDDDDDTTTQTTCCCGGGGGGGGGGGRRRRRRRRRRRRRRCCCQQQQQQQQQQWWWWQQQGGGGGGGGGGMMMMMMMMMMJJJJJJJJTRGGRRIKKKKKKKKKKKKKKVVVVVVLLLLLLMMMMMMMMDDRMMMM
    RRRRDDDDDDDTTQTTCCCGGCGGGGGGGGRRRRRRRRRRRRRRCCCCCQQQQQQQQWQWWWQQGGGGGGGGGGMMMMMMMMMMJTTTTTJTTGGGGRIKPPKKKQQKKKKVVVVVVVVVLLLLLMMMMMMMMMMMMMMZ
    RRRRDDDDDDDTTQQQCCVCCCCCDGGDGGRRRRRRRRRRRRRRCCCCQQQQQQQQQQQWWQQQGGGGGGGGGGMMMMMMMMMMTTTTTTTTTTGGGGKKPPPKKQQKKKKVVVVVVVVVLLLLLMMMMMMMMMMMMMMZ
    RRRRRDDDDDDRCCCCCCCCCCCCDDDDDDRRRRRRRRRRRRRRCCCCCCQQQQQQQQQWQQQGGGGGGGGGGGMMMMMMMMMMMTTTTTTTTTGGGPPPPPPPKQQKGKKVVVVVVVVVVLLLLHMMMMMXMMMMMMZZ
    RRRRDDDDDDDRCCCCCCCCCCCCCDDDDDRRRRRRRRRRRRRRCCCCCCQQQQQQQQQQQQQQGRRRRRGGGMMMMMMMNNTTTTTTTTTTTTGGPPPPPQQPQQKKGKKLLLVLLLLVVLLLLHMMMXLXXXXMMMMZ
    RRRRZDDDDDDRRCCCCCCCCCCDDDDDDDRRRRRRRRREEEECCCCCCCQQQQQQQQYYYYQYYRRRRRGGGGMMRRNNNNNNTTTTTTTTTTTTXXPPQQQQQQKKGGGLLLLLLLLLLLLLLLMKMXXXXXXZZZZZ
    ZRRRZZDDDRRRRRCCCCCDDDDDDDDDDCDDOOEEEEEEEEEECCCCCCQQQQQYYCYYYYYYYYYRRRRGGGRRRRRRNNNTTTTTTTTTTTTTTXXQQQQQQQQQQLLLLLLLLLLLLLLLLLXXXXXXXXXXXXXZ
    ZRZRZDDDDRRRRRCCCCCDDDDDDDDDFDODOOOEEEEEEEEECCCCCEQQAAYYYYYYYYYYYYYRRRRGGRRRRRRRNNNNNTTTTTTTTTTTXXQQQQQQQQQQQLLLLLLLLLLLLLLLLXXXXXXXXXXXXZZZ
    ZZZZZZZZZRRRRRRCCCCCDDDDDDDDDDOOOOOEEEEEEELEEEEEEEQQAYYYYYYYYYYYYYRRRRRRRRNNNRNRNNNNNTTTTTTTTTTTXQQAQQQQQQQQQLLLLLLLLFLLLLPXXXXXGXXXXXXXXZZZ
    ZZZZZZZRZZRRRRRRRCCCDDDDDDDDDOOOOOOOEEEEELLEEEEEEEQQQRRYYYYYYYYYYYRRRRRRRRNNNNNRNNNNNTTTTTUTTTTTTQQAQQQQQQQQQLLLLLLLFFFPPPPPXXXXXXXXXXXXXZZZ
    ZZZZZZRRRRRRRRRRDDDDDDDDDDDDDOOOOOOOEEELLLCLLEEEEEEQQRYYYYYYYYYYYYRRRRRRRRRNPNNRNNNNTTNTUUUUBBTBBBQQQQQQQQQQZLLLLLLLFFPPPPPNXXXXVGGXXXXXXXZZ
    ZZZZZZZRRRRRRRRRRRRDDDDDDDDKDOODDOOOLLLLLLLLLEEEEEQQQRYYYYYYYYYYYYRRRRRRRRRRNNNNNNNNTTNTTUUUBBBBBQQQQQQQQQQQZZZZZLLLLPPPPPPPPXXVVGXXXXXXRXVZ
    ZZZZZZZRRRRRRRRRRRKDDDDDDDDDDDDDDOOOLLLLLLLLEEEEEEEEQYYYYYYYYYYYRRRRRRRRRRRRNNNNNNNNNNNUQUUUBBBBBQQQQQQQQQZZZZZZZZLLTPPPPPPPPPXVVGVVXXXXVVVZ
    ZZZZZZRRRRRRRRRRRRRDDDDDDDDDDDGDDOOOLLLLLLLLEEEEEEEEEEEYYYYYYYRRRRRRRRRRRRRRRRNNNNNNNNUUUUUUEEBBBBBQQQQQQZZZZZZZZZZLLLLPPPPPPXXXVVVVXXVVVVZZ
    ZZZZZZZZZRRRRRRRRRDDDDDDDDDDDDDDDDDOLLLLLLLLLEEEEEEEEEWYIYYYYDRRRRRRRRRRRRRRRNNNNNNNNNUUUUUUEEDDBDDQQQQZZZZZZZZZZZZZZZPPPPPPXXGGGGVVVXXVVVZZ
    ZZZZZZZZZZRRRRRRRRDDDDDDDDFDDDDDDDDOLLLLLLLLLLEEEEEEEEELIIIYDDDRRRRRRRRRRRRRNNNNNNNNNNNUUUUUUEEDBDDDQQZZZZZZVVZZVZZZZZZPPPPPPXGGGGGVVVVVVVZZ
    ZZZZZZZZZRRRRRRRRRDDDDDDDFFDFFWDDDDOLLLLLLLLLLEEEEEEEETIIIIIIDDDDRRRRRRRRRRRRRRNNYNSNNNNUUUUUEEDDDDDDTZZZOVZVVVVVVZZZZZZZPPFGGGGGGGGVVVVVVZZ
    ZZZZZZZZURRRRRRRYDDDDDDFFFFFFFFFDZZZLLLLLLLLLLLEEEEEEEEEEIIIIDDDDRRRRRRRRRRRYRRYYYNSNNMMMMMUEEEEDDDDDDDDJVVVVVVVVVZZZZZZZPFFGGGGGGGVVVVVZZZZ
    ZZZZZZZZUARWRRRYYYDDDDFFFFFFFFFFAZZZLZNLLLLLLLEEEEEBBEEIIIIIIIIDDRRRRRRRRRRRYYYYYNSSMMMMMMMEEEEDDDDDDDDDDVVVVVVVVVVZZZZZZZFFGGGGGGGGVVVVZZZZ
    ZZZRRRRUUUBUKKKYYYDDDDFFFFFFFFFFAAZZZZNNLLLLLLEEEEEEBEIIIIIIIIIDDDRRRRRRRRRRYYYYYSSSSMMMMMEEEEEEDDDDDDDXDDRVVVVVVVVZZZZZFFFFGGGGGGVVVVVZZZZZ
    ZPPTRRRUUUUUKYKYYYYYDDDFFFFFFFUAAUSZZZNNLLLLLLDEEEEEEEPIIIIICIIDDRRRWWWRRRRYYYYYYYTSMMMMMMMEEEEEDDDDDDDDDDVVVVVVVVVCZZZZFFFFFFGGVVVVVVVZZZZZ
    PPPPRRUUUUUUYYYYYYYYYDFFFFFFFFUUUUUZZNNLLLLLLDDEEEEEPPPIIIIICDDDDDRRRWWWRRRYYYYYYYMMMMMMMMMEEEEDDDDDDDDDDDVVVVVVVVVVOZZPFFFFFFGVVVVVMVVZZZZZ
    PPPPPRUUUUUURYYYYYYYRFFFFFFFFFUUUUUUUNNNNLLLLDEEEEEEEIIIIILIDDDDDDRWWWWWRRRRYYYYQQSSMMMMMEEEEDDSDDDDDDDDDVVVVVVVVVVVVZPPFFFFFFGVVVFFMZGZZZZZ
    TPPPPRPUUUUUUSYYYYYYRRFFFFFFFFUUUUPUUNNZNZLLDDEEEEUUUUUUIIEEDDDDDDDDDDQWQQRRYYQQQQQSMQMMMEEEDDDDDDDDDDDDDVVVVVVVVVVVPPPPFFFFFVVVMMFMMZZZZZZZ
    PPPPPPPPPPPPUSYYYYYYRRFFFFFFFUUUUUUUTZZZZZKLLLMLEELUUUUUEEEEEDHHDDTHHEQWQQQQYQQQQQQSSMMMMMEEEDDDDDDDDDVEVVVVVVPPPPPYYPPFFFFFFFVVMMMMMMZZZZZZ
    PPPPPPPTPPPPUUUYYYYYYYJFFFFFFFFUUUZYTZBZZZZZKKLLLELLUUEEEEEEEHHHHHHHHHQQQQQQQQQQQQQQSMMMMMEEDDDDDDDDDDVVVVVVVVVVPPPYYPPPFFFFFFFMMMMMMMZMZZZZ
    PPPPPPPPPPPPUYYYYYYYYTYFFFFVVVYYYYYYTZZZZZZZKKZLLLLEEEEEEEEEEHHHHHHHHHJQQQQQQQQQQQQQSSSSMMMMDDDDDDDDDDVVVVVVVVPPPPPPPPPPFPFFFFMMMMMMMMMMMMZZ
    PPPPPPPPPPPPUYYYYYYYYYYFYYYYYYYYYYYTTTZZZZZZZZZZZZLLLEEEEEEEEHHHHHHHHHJJQQQQQQQQQQQQSSSSIIIYDDDDDDDDDDDVVVVVVVPNNPPPPPPPPPFFFMMMMMMMMMMMMMZZ
    PPPPPPPPPPYYYYYYYYYYYYYWYYYYYRYYYYYTYYOZZZZZZZZZZLLLEEEEEEEEEHHHHHHHHHJJJQQQQQQQQQQQQQSIIIYYDDLDIGGDGGGGVVVVVVVVVBPPPPPPPPFFFMMMMMMMMMMMMMMM
    PPPPPPPRVVYYYYYYYYYYYYYYYYYYYYYYYYYYYGZZZZZZZZJJZLLLLEEEEEEEEHHHHMMMMLJJQQWQQQQQQQQQQSSIIIYYYDGIIGGGGGGGVVVVVVVVVVPPPPPPPPPPPMVMMMMMMMMMMDDD
    PPPPPPPRVVVYYYYYYYYYYYKYYYYYYYYYYYYYYGZZZZZZOZZZOLLLLLEEEEEEHHHHMMMMMLJJQWWQQQQQQQQQSSSIIIIIYYGGIGGGGGGGVVVVVVVVVVVPPPPPPPPJJMMMMMKMMMMMMMMD
    PPPPRPPVVVVYYYYYYYYYYYKYYYYYYYYYYYYYGGGGZOOOOOZYOLLLLLEELEEEEHHMMMMMLLQQQQQQQQQQQQQQQIIIIIIIYYGGGGGGGGVVVVVVVVVVVVPPPPPPPPKJJMMMMKKMMMMMMDDD
    PPPPPVVVVVVVVVYYVYYVVVVVYYYYYYYYYYYYYGKKZOOOOOZOOLLLLLLLLLLEEHMMMMMMMLLLQQBQQQQQQQQQQQQIIIIIIYGGGGGGVVVVVVVVVVVVVPPPPPPPPPKKKXKIMKKMCMMMMDDD
    PPPPVVVVVVVVVVVVVYVVVVVVVVYYYYYYYYYYYYKKZOOOOOOOOOLLLLLLLDLLMMMMMMMMMLLLLQBBBQQQQQQQQQQIIIIIIIFGGGGGVVVVVVVVVVVMVPPPPPPPPKKKKKKKKKKCCCMMMMDD
    PVPPPVVVVVVVVVVVVVVVVVVVVVVVYYYYYYYYYJKKOOOOOOOOOOLOLLLLLDDRMMMMMMMMMLLLLBBBBBQQQQQQIIIIIIIIIIFFGGGGVVVVVVVVVVVVVPPPPPPPTKKKKKKKKKKKKCMMMMMM
    VVPPVVVVVVVVSVVVVVVVVVVVVVVVVYLYYYYYYYKKKOOOOOOOOOOOLLLLLDDDDMMMMMMLLLLLLLLBBBQQQQIIIIIIIIIIYYYYGGGGGVVVVVVVVVVVVPPPPPPKKKKKKKKKKKKKCCMMMMMH
    VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVYYYYKKYKKKKOOOOOOOOOOLLLLLDDDDDMMMMMMMBBBLBBLBIBBIIIIIIIIIIYYYYYYYGGGGGVVVVVVVVCCCCYPPPPPBKKKKKKKKKKKKKKHMHMHH
    VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVYYYYKKKKKKOOOOOOUOOOOOOLDDDDDDMMMMMMMBBBBBBBBIIIIIIIIIIIIYYYYYYYYYGQGVVVVVVVVVCCCCCCPPPPPPKKKKKKKKKKKKHHHHHHH
    VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVKYYKKKKKKOOYOOOOOOIOOOVVVDMMMMMMMMMMMBBBBBBBIIIIIIIIIIIIYYYYYYYYYYQQVQQVVVVVVCCCCCCCPPPPKKKKKKKKKKKKKHHHHHHH
    VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVKJYKKKKKTOOOOODDOOIOOVVVVVVVMMAMMMMMBBBBBBBBILIIIIIIIIIIIKYYYYYYYYQQQQQVVVCCCCCCCCCPPPPKKKKKKKKKKKKKHHHHHHHH
    VVVVVVVVVVVVVVVVOVVVVVVVVVVVVVVVKKKKKKKKKAOKOODDOIIOVVVVVVVVVMAAMSSMBBBBBBBBILIIIIIIIIIIIKYYYYYYYQQQQQQQVVHHCCCCCCCBBPKKKKKKKKKKKKKKHHHHHHHH
    """;

/*
cell perimeter = 4 - # of adjacent cells with same value
cell area = 1

region = set of contiguous cells with same value
region perimeter = sum of cell perimeters
region area = size of region (# of cells)
 - start at mapOffset = 0
 - while mapOffset < mapLength
    - while (mapOffset < mapLength && map[mapOffset].Seen) mapOffset++;
    - if (mapOffset < mapLength) 
      - recursively check each neighbor for same value and not seen
        - mark each cell as seen along the way
        - first time seeing a cell its cell perimeter can be set based on equation above
        - back at root: (can both be calculated during traversal)
         - region area = number of [distinct] leaf nodes
         - region perimeter = sum region cell perimeters
region price = region perimeter * region area

problem answer = sum(region prices)
 */

const bool _debug = false;

var lines = (_debug ? _testInput : _puzzleInput).GetLines();
var map = new Map(lines);
var mapOffset = 0;
var currCell = map.GetCellByOffset(mapOffset);
var totalPrice = 0L;

while (mapOffset < map.Size)
{
    while (currCell.Seen && ++mapOffset < map.Size)
    {
        Console.WriteLine($"Skipping offset {mapOffset - 1}, already seen.");
        currCell = map.GetCellByOffset(mapOffset);
    }

    if (mapOffset < map.Size)
    {
        Console.WriteLine($"Processing cell at {mapOffset} [{currCell.Value}].");
     
        var region = currCell.Region;
        
        totalPrice += region.Price;
        map.MarkAsSeen(region);
        mapOffset++;
    }

    if (mapOffset >= map.Size) break;

    currCell = map.GetCellByOffset(mapOffset);
}

Console.WriteLine($"Total Price: {totalPrice}");

internal readonly record struct Map
{
    private const int _xRank = 0;
    private const int _yRank = 1;

    public Map(List<string> rawData)
    {
        RawData = rawData;
        Data = new Cell[RawData[0].Length, RawData.Count];

        // Fill Cell values
        for (var row = 0; row < Height; row++)
        {
            for (var col = 0; col < Width; col++)
            {

                Data[col, row] = new Cell(RawData[row][col], row * Width + col);
            }
        }

        // Set Cell neigbors
        var mapOffset = -1;

        while (++mapOffset < Size)
        {
            var cell = Data[Column(mapOffset), Row(mapOffset)];

            if (mapOffset >= Width) // Not first row
            {
                // Add UP
                AddNeighbor(cell, mapOffset - Width);
            }

            if (mapOffset < Size - Width) // Not last row
            {
                // Add DOWN
                AddNeighbor(cell, mapOffset + Width);
            }

            if (mapOffset % Width > 0)
            {
                // Add LEFT
                AddNeighbor(cell, mapOffset - 1);
            }

            if (mapOffset % Width < Width - 1)
            {
                // Add RIGHT
                AddNeighbor(cell, mapOffset + 1);
            }
        }
    }

    public List<string> RawData { get; }

    internal readonly int Width => Data.GetLength(_xRank);

    internal readonly int Height => Data.GetLength(_yRank);

    internal readonly int Size => Width * Height;

    internal readonly Cell[,] Data { get; }

    internal Cell GetCellByOffset(int offset)
    {
        var x = offset % Width;
        var y = offset / Width;

        return Data[x, y];
    }

    internal void MarkAsSeen(Region region)
    {
        foreach (var cell in region.Cells)
        {
            Data[Column(cell.Offset), Row(cell.Offset)].Seen = true;
        }
    }

    private void AddNeighbor(Cell cell, int offset)
        => cell.AddNeighbor(Data[Column(offset), Row(offset)]);

    private int Column(int offset) => offset % Width;

    private int Row(int offset) => offset / Width;
}

internal record struct Cell(char Value, int Offset)
{
    private readonly HashSet<Cell> _neighbors = [];
    internal readonly IReadOnlyList<Cell> Neighbors => _neighbors.ToList().AsReadOnly();

    internal bool Seen { get; set; }

    private int _perimeter = -1;
    internal int Perimeter
    {
        get
        {
            if (_perimeter > -1) return _perimeter;

            ValidateNeighbors();

            var thisVal = Value;

            _perimeter = 4 - _neighbors.Count(n => n.Value == thisVal);

            return _perimeter;
        }
    }

    internal readonly Region Region
    {
        get
        {
            ValidateNeighbors();

            var region = new HashSet<Cell>();

            Walk(this, Value, region);

            return new(region);
        }
    }

    internal readonly void AddNeighbor(Cell neighbor) => _neighbors.Add(neighbor);

    private readonly void ValidateNeighbors()
    {
        if (_neighbors.Count < 2 || _neighbors.Count > 4)
            throw new Exception($"Invalid number of neighbors ({_neighbors.Count})");
    }

    private static void Walk(Cell currCell, char regionValue, HashSet<Cell> region)
    {
        if (region.Contains(currCell) || currCell.Value != regionValue) return;

        region.Add(currCell);

        foreach (var neighbor in currCell.Neighbors)
        {
            Walk(neighbor, regionValue, region);
        }
    }
}

internal readonly record struct Region(IEnumerable<Cell> Cells)
{
    internal readonly int Perimeter => Cells.Sum(c => c.Perimeter);

    internal readonly int Area => Cells.Distinct().Count();

    internal readonly long Price //=> Perimeter * Area;
    {
        get
        {
            var p = Perimeter;
            var a = Area;
            var price = p * a;

            Console.WriteLine($"\tPerimeter: {p}");
            Console.WriteLine($"\tArea: {a}");
            Console.WriteLine($"\tPrice: {price}");

            return price;
        }
    }
}