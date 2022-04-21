package code;

import lombok.AllArgsConstructor;
import lombok.Getter;

@AllArgsConstructor
@Getter
public class P67580_ALL { private final String d; private final int description;
    public static P67580_ALL rescue(String person) {
        return new P67580_ALL(person.split(" ")[0], Integer.parseInt(person.split(" ")[1]));
    }
}
