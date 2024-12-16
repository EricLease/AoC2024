﻿using Utilities;

// Expect 1206
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

// Solved: 885394
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

    Part 2

Calculate region price as # sides * area

    Algorithm:

        Calculate number of region sides as sum of each cell's contribution
        Side contribution:
            
            Simple cases:

            cell perimeter : 4 :: cell sides : 4    _
                                                   |_|
                                                    
            cell perimeter : 0 :: cell sides : 0   ___
                                                  |   |
                                                  | x |
                                                  |___|

            corners count as 1:
                1. standard corners: 
                    - iterate through neighbors
                    - for ith neighbor, check if neighbor[i] and neighbor[i+1] values both differ (both perim)
                        - true: this is a standard corner:          v
                                                                 ____ 
                                                                    >|
                2. inverted corner:
                    - while iterating through corners, if neighbor[i] differs (perim) but neighbor[i+1] does not differ
                        - check diagonal (right turn relative to current neighbor) 
                            - if neighbor[i+1] has neighbors, and neighbor[i+1]'s neighbor[i] value matches current cell value -> inverted corner
                                                           ___
                                                              |
                                                             >|___
                                                               ^  |

 */

const bool _debug = false;

var lines = (_debug ? _testInput : _puzzleInput).GetLines();
var map = new Map(lines);
var mapOffset = 0;
var currCell = map.GetCellByOffset(mapOffset);
var totalPrice = 0L;
var regions = new List<Region>();

while (mapOffset < map.Size)
{
    while (currCell.Seen && ++mapOffset < map.Size)
    {
        if (_debug) Console.WriteLine($"Skipping offset {mapOffset - 1}, already seen.");
        currCell = map.GetCellByOffset(mapOffset);
    }

    if (mapOffset < map.Size)
    {
        if (_debug) Console.WriteLine($"Processing cell at {mapOffset} [{currCell.Value}].");

        var region = currCell.Region;

        totalPrice += region.Price;
        regions.Add(region);
        map.MarkAsSeen(region);
        mapOffset++;

        if (_debug)
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }

    if (mapOffset >= map.Size) break;

    currCell = map.GetCellByOffset(mapOffset);
}

Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
Console.Clear();

var i = 0;
var colors = new List<List<ConsoleColor>>
{ 
    new() 
    {
        ConsoleColor.White,
        ConsoleColor.Magenta,
        ConsoleColor.DarkMagenta,
        ConsoleColor.Red,
        ConsoleColor.DarkRed,
    },
    new()
    {
        ConsoleColor.White,
        ConsoleColor.Cyan,
        ConsoleColor.DarkCyan,
        ConsoleColor.Blue,
        ConsoleColor.DarkBlue,
    },
    new() 
    {
        ConsoleColor.White,
        ConsoleColor.Yellow,
        ConsoleColor.DarkYellow,
        ConsoleColor.Green,
        ConsoleColor.DarkGreen,        
    }
};

foreach (var region in regions)
{
    var palette = colors[i++ % colors.Count];
    region.Print(map.Width, palette, ConsoleColor.White);
}

Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
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

            // Add [and iterate] in this order: ^ > v <
            AddNeighborOrDummy(cell, mapOffset - Width, mapOffset >= Width); // Up, Not first row
            AddNeighborOrDummy(cell, mapOffset + 1, mapOffset % Width < Width - 1); // Right, not last column
            AddNeighborOrDummy(cell, mapOffset + Width, mapOffset < Size - Width); // Down, not last row
            AddNeighborOrDummy(cell, mapOffset - 1, mapOffset % Width > 0); // Left, not first column
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

    private void AddNeighborOrDummy(Cell cell, int nOffset, bool condition)
    {
        if (condition)
        {
            AddNeighbor(cell, nOffset);
            return;
        }

        cell.AddNeighbor(offset: nOffset);
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

    private int _sideCount = -1;
    internal int SideCount
    {
        get
        {
            if (_sideCount > -1) return _sideCount;

            ValidateNeighbors();

            var thisVal = Value;

            _sideCount = 0;

            for (var i = 0; i < _neighbors.Count; i++)
            {
                var n = _neighbors.ElementAt(i);
                var nextN = _neighbors.ElementAt((i + 1) % 4);
                var diag = nextN.Value == thisVal
                        ? nextN.Neighbors.ElementAt(i).Value
                        : -1;

                if (thisVal != n.Value &&
                    (thisVal != nextN.Value || thisVal == diag)) _sideCount++;
            }

            return _sideCount;
        }
    }

    internal readonly Region Region
    {
        get
        {
            ValidateNeighbors();

            var region = new HashSet<Cell>();

            Walk(this, Value, region);

            return new(region.OrderBy(c => c.Offset));
        }
    }

    internal readonly void AddNeighbor(Cell? neighbor = null, int offset = -1)
        => _neighbors.Add(neighbor ?? new Cell('!', offset));

    private readonly void ValidateNeighbors()
    {
        if (_neighbors.Count != 4)
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

    internal readonly int SideCount => Cells.Sum(c => c.SideCount);

    internal readonly int Area => Cells.Distinct().Count();

    internal readonly long Price => SideCount * Area;

    internal readonly void Print(int width, List<ConsoleColor> back, ConsoleColor fore)
    {
        foreach (var cell in Cells)
        {
            Console.CursorLeft = cell.Offset % width;
            Console.CursorTop = cell.Offset / width;
            Console.ForegroundColor = cell.SideCount == 0 ? back[4] : fore;
            Console.BackgroundColor = back[cell.SideCount];
            Console.Write(cell.Value);
        }
    }
}