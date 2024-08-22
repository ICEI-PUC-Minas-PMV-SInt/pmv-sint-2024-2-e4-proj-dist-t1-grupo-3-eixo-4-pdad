# Trade-offs de Características de Qualidade

FURPS+ é um sistema para a classificação de requisitos, o acrônimo representa categorias que podem ser usadas na definição de requisitos, assim como representa atributos de Qualidade de Software.

O modelo FURPS+ fornece uma estrutura para categorizar os requisitos não-funcionais de um produto de software em diferentes áreas de qualidade, como Usabilidade, Desempenho, Confiabilidade e Suportabilidade. Ao considerar essas categorias no desenvolvimento do sistema "FocusFlow", é importante entender os trade-offs que surgem ao priorizar uma característica em detrimento de outra.

As categorias de requisitos não-funcionais para o produto de software "FocusFlow", conforme o modelo FURPS+, seriam:

1. **Usabilidade (Usability):**: 
   
   É o atributo que avalia a interface com o usuário. Possui diversas subcategorias, entre elas: prevenção de erros; estética e design; ajudas (Help) e documentação; consistência e padrões.

2. **Desempenho (Perfomance)**: 
   
   Avalia os requisitos de desempenho do software. Podendo usar como medida diversos aspectos, entre eles: tempo de resposta, consumo de memória, utilização da CPU, capacidade de carga e disponibilidade da aplicação.

3. **Confiabilidade (Reliability)**: 
   
   Refere-se a integridade, conformidade e interoperabilidade do software. Os requisitos a serem considerados são: freqüência e gravidade de falha; possibilidade de recuperação; possibilidade de previsão; exatidão; tempo médio entre falhas (MTBF).

4. **Suportabilidade (Supportability)**: 
   
   Os requisitos de suportabilidade agrupam várias características, como: testabilidade, adaptabilidade, manutenibilidade, compatibilidade, configurabilidade, instalabilidade, escalabilidade, localizabilidade entre outros.

**Trade-offs de Características de Qualidade para o FocusFlow:**

**001. Usabilidade x Desempenho:**
   - Usabilidade é priorizada sobre Desempenho. Isso significa que, ao projetar o sistema, é mais crucial garantir que a interface seja intuitiva e fácil de usar, mesmo que isso possa resultar em uma performance ligeiramente inferior. Por exemplo, a implementação de uma interface gráfica mais sofisticada para melhorar a experiência do usuário pode aumentar a carga de processamento, potencialmente afetando a rapidez com que o sistema responde.
   
**002. Usabilidade x Confiabilidade:**
   - Usabilidade é considerada mais importante que Confiabilidade. Embora a estabilidade e a segurança sejam essenciais, a prioridade é garantir que os usuários possam interagir com o sistema de maneira eficaz e eficiente. No entanto, isso não significa que a confiabilidade seja negligenciada, mas sim que pode haver situações em que uma melhoria na usabilidade é preferida em relação a um pequeno compromisso na robustez do sistema.

**003. Usabilidade x Suportabilidade:**
   - Usabilidade também supera Suportabilidade. O foco inicial é garantir que os usuários possam utilizar o sistema com facilidade, mesmo que isso implique um esforço maior nas etapas de manutenção e suporte. Por exemplo, customizações de interface para melhorar a usabilidade podem resultar em maior complexidade para futuras atualizações, mas essa escolha é justificada pelo impacto positivo na experiência do usuário.

**004. Desempenho x Confiabilidade:**
   - Confiabilidade é mais importante que Desempenho. Isso indica que o sistema deve ser robusto e estável, mesmo que ocasionalmente sacrifique a velocidade de resposta. Por exemplo, implementar verificações de integridade adicionais para garantir que os dados sejam processados corretamente pode adicionar latência, mas esse compromisso é aceito para garantir que o sistema opere de maneira confiável e segura.

**005. Desempenho x Suportabilidade:**
   - Desempenho é priorizado sobre Suportabilidade, sugerindo que a rapidez do sistema é mais crucial do que a facilidade de manutenção e suporte. Isso pode levar a decisões de arquitetura que favorecem a performance, como a otimização de código ou a utilização de tecnologias mais rápidas, mesmo que isso torne o sistema mais difícil de manter a longo prazo.

**006. Confiabilidade x Suportabilidade:**
   - Confiabilidade supera Suportabilidade, indicando que o sistema deve ser robusto e seguro, mesmo que isso torne as tarefas de manutenção mais complexas. Por exemplo, a implementação de mecanismos avançados de segurança e recuperação de falhas pode exigir processos de manutenção mais rigorosos, mas a prioridade é garantir que o sistema seja estável e seguro para os usuários.

**Considerações Finais**

Ao equilibrar esses trade-offs, é essencial considerar o contexto de uso do "FocusFlow" e o perfil dos usuários. A matriz de importância relativa orienta as decisões, mas é importante estar ciente de que essas escolhas podem influenciar a experiência geral do usuário e o ciclo de vida do produto. A priorização clara das categorias de qualidade permite que a equipe de desenvolvimento faça escolhas informadas, alinhando o produto final com os objetivos de negócio e as expectativas dos usuários.


A importância relativa de cada categoria:

| Categoria | Usabilidade | Desempenho | Confiabilidade | Suportabilidade |
| --- | --- | --- | --- | --- |
| Usabilidade | - | > | > | > |
| Desempenho | < | - | < | > |
| Confiabilidade | < | > | - | > |
| Suportabilidade | < | < | < | - |

> Nesta matriz, o sinal ">" indica que a categoria da linha é mais importante que a categoria da coluna, e o sinal "<" indica que a categoria da linha é menos importante que a categoria da coluna. Por exemplo, a Usabilidade é considerada mais importante que o Desempenho, Confiabilidade e Suportabilidade, enquanto o Desempenho é considerado mais importante que a Suportabilidade, mas menos importante que a Usabilidade e Confiabilidade, e assim por diante.


**A matriz mostra a importância relativa entre as categorias de Usabilidade, Desempenho, Confiabilidade e Suportabilidade.**

Interpretação da Matriz

**Na matriz:**

- Usabilidade é mais importante que Desempenho (`>`), Confiabilidade (`>`), e Suportabilidade (`>`).
- Desempenho é menos importante que Usabilidade (`<`) e Confiabilidade (`<`), mas mais importante que Suportabilidade (`>`).
- Confiabilidade é mais importante que Usabilidade (`>`), Desempenho (`>`), e Suportabilidade (`>`).
- Suportabilidade é menos importante que todas as outras categorias.

**Implicações:**

- Confiabilidade é a categoria mais valorizada, seguida de Usabilidade, Desempenho, e, por fim, Suportabilidade.
- Usabilidade é considerada crucial, especialmente em relação ao Desempenho e Suportabilidade, mas ainda é menos prioritária que a Confiabilidade.
- Desempenho é importante, mas é subordinado à Confiabilidade e Usabilidade.
- Suportabilidade tem a menor prioridade, indicando que as outras categorias têm precedência sobre a facilidade de manutenção.


[Retorna](../README.md)

